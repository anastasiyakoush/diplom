using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Common.FilterCriterias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PublicLessonController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IPublicLessonService _publicLessonService;
    private readonly IConfiguration _configuration;

    public PublicLessonController(IMapper mapper, IPublicLessonService publicLessonService, IConfiguration configuration)
    {
      _mapper = mapper;
      _publicLessonService = publicLessonService;
      _configuration = configuration;
    }

    [HttpDelete("planning/{id}")]
    public async Task<IActionResult> DeletePlanningAsync(int? id)
    {
      try
      {
        await _publicLessonService.DeletePlanningAsync(id);
        return Ok();
      }
      catch (ArgumentNullException)
      {
        return NotFound();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int? id)
    {
      try
      {
        await _publicLessonService.DeleteAsync(id);
        return Ok();
      }
      catch (ArgumentNullException)
      {
        return NotFound();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PublicLessonDto>>> GetAllAsync()
    {
      try
      {
        return Ok(await _publicLessonService.GetAllAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("planning")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PlanningPublicLessonDto>>> GetAllPlanningAsync()
    {
      try
      {
        return Ok(await _publicLessonService.GetAllPlanningLessonsAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("planning/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlanningPublicLessonDto>> GetPlanningAsync(int? id)
    {
      try
      {
        var uchebnyjPlanDto = await _publicLessonService.GetPlanningLessonAsync(id);

        if (uchebnyjPlanDto == null)
        {
          return NotFound();
        }

        return Ok(uchebnyjPlanDto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PublicLessonDto>> GetAsync(int? id)
    {
      try
      {
        var uchebnyjPlanDto = await _publicLessonService.GetAsync(id);

        if (uchebnyjPlanDto == null)
        {
          return NotFound();
        }

        return Ok(uchebnyjPlanDto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("teacher/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PublicLessonDto>> GetByTeacherAsync(int? id)
    {
      try
      {
        var uchebnyjPlanDto = await _publicLessonService.GetByTeacherAsync(id);

        if (uchebnyjPlanDto == null)
        {
          return NotFound();
        }

        return Ok(uchebnyjPlanDto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PublicLessonDto>>> FilterUchebnyePlansAsync(PublicLessonFilterCriterias criterias)
    {
      try
      {
        return Ok(await _publicLessonService.FilterAsync(criterias));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PublicLessonDto>>> SearchAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _publicLessonService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PublicLessonDto>> AddOrUpdateTeacherAsync(PublicLessonDto publicLessonDto)
    {
      try
      {
        var updatedTeacherDto =
          await _publicLessonService.AddOrUpdateAsync(publicLessonDto);

        if (updatedTeacherDto == null)
        {
          return NotFound();
        }

        return Ok(updatedTeacherDto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("upload"), DisableRequestSizeLimit]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UploadDocumentAsync([FromQuery] int type)
    {
      try
      {
        var documentTypeName = type == 1 ? "AnalisUroka" : "PlanZanytiya";

        var file = Request.Form.Files.FirstOrDefault();
        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var dir = _configuration.GetSection("DocumentsFolder").Value;

        var directory = Path.Combine(dir, documentTypeName);

        if (!Directory.Exists(directory))
        {
          Directory.CreateDirectory(directory);
        }

        var link = Path.Combine(directory, fileName);

        using (var stream = System.IO.File.Create(link))
        {
          await file.CopyToAsync(stream);
        }

        return Ok(new { Link = link });
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("planning")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlanningPublicLessonDto>> AddOrUpdatePlanningLessonAsync(PlanningPublicLessonDto publicLessonDto)
    {
      try
      {
        var updatedTeacherDto =
          await _publicLessonService.AddOrUpdatePlanningPublicLessonAsync(publicLessonDto);

        if (updatedTeacherDto == null)
        {
          return NotFound();
        }

        return Ok(updatedTeacherDto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("compare")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ComparableLessonsDto>>> ComapreLessonsAsync()
    {
      try
      {
        return Ok(await _publicLessonService.GetComparableLessonAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
