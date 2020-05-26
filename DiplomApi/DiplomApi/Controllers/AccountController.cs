using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL.DAL;
using DiplomApi.PostModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Common.Enums;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ApplicationContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public AccountController(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      RoleManager<IdentityRole> roleManager,
      ApplicationContext context,
      IMapper mapper)
    {
      _context = context;
      _userManager = userManager;
      _signInManager = signInManager;
      _mapper = mapper;
      _roleManager = roleManager;
    }
    [HttpGet("user/{id}")]
    public async Task<ActionResult<PostUserModel>> GetUserAsync(string id)
    {
      try
      {
        if (string.IsNullOrEmpty(id))
        {
          return BadRequest();
        }

        var user = await _userManager.FindByIdAsync(id);
        var roles = await _userManager.GetRolesAsync(user);

        var model = new PostUserModel
        {
          UserName = user.UserName,
          Id = user.Id,
          Role = roles.FirstOrDefault().Equals("admin", StringComparison.CurrentCultureIgnoreCase) ? Role.Admin : Role.User
        };

        return Ok(model);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("search")]
    public async Task<ActionResult<IList<PostUserModel>>> SearchUsersAsync([FromBody] string searchQuery)
    {
      try
      {
        searchQuery = Regex.Replace(searchQuery.Trim(), "\\s+", " ").ToLower();

        var users = await _userManager.Users
          .Where(x => x.UserName.ToLower().Contains(searchQuery))
          .ToListAsync();

        var result = new List<PostUserModel>();
        foreach (var user in users)
        {
          var roles = await _userManager.GetRolesAsync(user);

          result.Add(new PostUserModel
          {
            Id = user.Id,
            UserName = user.UserName,
            Role = roles.FirstOrDefault().Equals("admin", StringComparison.CurrentCultureIgnoreCase) ? Role.Admin : Role.User
          });
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> AddOrUpdateUser(PostUserModel model)
    {
      try
      {
        var user = await _userManager.FindByIdAsync(model.Id);

        var role = Enum.GetName(typeof(Role), model.Role);

        if (user is null)
        {
          var userInDb = await _userManager.FindByNameAsync(model.UserName);

          if (userInDb != null)
          {
            throw new Exception("Такое имя пользователя уже занято");
          }

          user = _mapper.Map<IdentityUser>(model);

          var t = await _userManager.CreateAsync(user, model.Password);
          await _userManager.AddToRoleAsync(user, role);

        }
        else
        {
          if (user.UserName != model.UserName)
          {
            await _userManager.SetUserNameAsync(user, model.UserName);
          }

          var hash = _userManager.PasswordHasher.HashPassword(user, model.Password);
          if (hash != user.PasswordHash)
          {
            user.PasswordHash = hash;
          }

          var roles = await _userManager.GetRolesAsync(user);
          if (!roles.Any(x => x == role))
          {
            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, role);

          }
          await _userManager.UpdateAsync(user);

        }

        await _context.SaveChangesAsync();

        model.Id = user.Id;
        model.UserName = user.UserName;
        return Ok(model);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [AllowAnonymous]
    [HttpPost("signin")]
    public async Task<ActionResult> SignIn(PostUserModel model)
    {
      try
      {
        var user = await _userManager.FindByNameAsync(model.UserName);

        var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

        if (!signInResult.Succeeded)
        {
          throw new Exception("Incorrect email or password.");
        }

        var roles = await _userManager.GetRolesAsync(user);

        model.Token = GenerateJwtTokenAsync(user.UserName, roles.FirstOrDefault(), user.Id);

        return Ok(model);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    //[Authorize(Roles = Roles.Admin)]
    [HttpGet("all")]
    public async Task<ActionResult> GetAll()
    {
      try
      {
        var t = HttpContext.User;
        var users = await _userManager.Users.ToListAsync();

        var result = new List<PostUserModel>();
        foreach (var user in users)
        {
          var roles = await _userManager.GetRolesAsync(user);

          result.Add(new PostUserModel
          {
            Id = user.Id,
            UserName = user.UserName,
            Role = roles.FirstOrDefault().Equals("admin", StringComparison.CurrentCultureIgnoreCase) ? Role.Admin : Role.User
          });
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    //[HttpGet("signout")]
    //public async Task<ActionResult> SignOut()
    //{
    //  try
    //  {
    //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    //    return Ok();
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
      try
      {
        var user = await _userManager.FindByIdAsync(id);

        await _userManager.DeleteAsync(user);

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    private string GenerateJwtTokenAsync(string username, string role, string userId)
    {
      var now = DateTime.Now;
      var expires = now.AddHours(8760);
      var secret = Encoding.ASCII.GetBytes("Some secret key for jwt token");
      var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature);
      var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, userId)
            };

      var jwtToken = new JwtSecurityToken(
              notBefore: now,
              claims: claims,
              expires: expires,
              signingCredentials: signingCredentials
          );

      return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
  }
}
