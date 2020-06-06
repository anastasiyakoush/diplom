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
using DiplomApi.PostModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Common.Enums;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlanController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IPlanService _planService;
    private readonly IConfiguration _configuration;

    public PlanController(IMapper mapper, IPlanService planService, IConfiguration configuration)
    {
      _mapper = mapper;
      _planService = planService;
      _configuration = configuration;
    }

    // [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<UchebnyjPlanDto>>> GetAllUchebnyePlansAsync(bool f = false)
    {
      try
      {
        var t = await _planService.GetAllUchebnyePlansAsync();
        if (t?.Count() > 0 && f)
        {
          t.Insert(0, new UchebnyjPlanDto { Id = null, RegistarcionnyjNomer = "Не выбрано" });
        }
        return Ok(t);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("uch/{id}")]
    public async Task<ActionResult<UchebnyjPlanDto>> GetUchebnyiPlanAsync(int? id)
    {
      try
      {
        var uchebnyjPlanDto = await _planService.GetUchebnyiPlanAsync(id);

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

    [HttpPost("uch/filter")]
    public async Task<ActionResult<List<UchebnyjPlanDto>>> FilterUchebnyePlansAsync(UchebnyiPlanFilterCriterias criterias)
    {
      try
      {
        return Ok(await _planService.FilterUchebnyePlany(criterias));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<ActionResult> AddOrUpdatePlanAsync(PostPlanModel postPlanModel)
    {
      try
      {
        switch (postPlanModel.PlanType)
        {
          case PlanType.ObrazovatelnyeStardarty:
            {
              await _planService.AddOrUpdateObrStandrtAsync(_mapper.Map<ObrazovatelnyjStandartDto>(postPlanModel));
            }
            break;
          case PlanType.TipovyePlany:
            {
              await _planService.AddOrUpdateTipovoyPlanAsync(_mapper.Map<TipovojUchebnyjPlanDto>(postPlanModel));
            }
            break;
          case PlanType.UchebnyePlany:
            {
              await _planService.AddOrUpdateUchebnyiPlanAsync(_mapper.Map<UchebnyjPlanDto>(postPlanModel));
            }
            break;
        }

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("upload"), DisableRequestSizeLimit]
    public async Task<ActionResult> UploadPlanAsync([FromQuery] int plan)
    {
      try
      {
        var planType = (PlanType)plan;
        var file = Request.Form.Files.FirstOrDefault();
        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var dir = _configuration.GetSection("DocumentsFolder").Value;
        var directory = Path.Combine(dir, planType.ToString());

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

    [HttpDelete("uch/{id}")]
    public async Task<IActionResult> DeleteUchebnyiPlanAsync(int? id)
    {
      try
      {
        await _planService.DeleteUchebnyiPlanAsync(id);
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

    [HttpGet("tip")]
    public async Task<ActionResult<List<TipovojUchebnyjPlanDto>>> GetAllTipPlansAsync(bool f = false)
    {
      try
      {
        var t = await _planService.GetAllTipovoyPlansAsync();
        if (t?.Count() > 0 && f)
        {
          t.Insert(0, new TipovojUchebnyjPlanDto { Id = null, RegistarcionnyjNomer = "Не выбрано" });
        }
        return Ok(t);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("tip/{id}")]
    public async Task<ActionResult<TipovojUchebnyjPlanDto>> GetTipovojPlanAsync(int? id)
    {
      try
      {
        var uchebnyjPlanDto = await _planService.GetTipovoyPlanAsync(id);

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

    [HttpDelete("tip/{id}")]
    public async Task<IActionResult> DeleteTipovojAsync(int? id)
    {
      try
      {
        await _planService.DeleteTipovoyPlanAsync(id);
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

    [HttpPost("tip/filter")]
    public async Task<ActionResult<List<UchebnyjPlanDto>>> FilterTipPlansAsync(TipovojPlanFilterCriterias criterias)
    {
      try
      {
        return Ok(await _planService.FilterTipovyePlany(criterias));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("obr")]
    public async Task<ActionResult<List<ObrazovatelnyjStandartDto>>> GetAllObrStandartsAsync(bool f = false)
    {
      try
      {
        var t = await _planService.GetAllObrStandartsAsync();
        if (t?.Count() > 0 && f)
        {
          t.Insert(0, new ObrazovatelnyjStandartDto { Id = null, RegistarcionnyjNomer = "Не выбрано" });
        }
        return Ok(t);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("obr/{id}")]
    public async Task<ActionResult<ObrazovatelnyjStandartDto>> GetObrStandartAsync(int? id)
    {
      try
      {
        var obrazovatelnyjStandart = await _planService.GetObrStandartAsync(id);

        if (obrazovatelnyjStandart == null)
        {
          return NotFound();
        }

        return Ok(obrazovatelnyjStandart);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("obr/{id}")]
    public async Task<IActionResult> DeleteObrStandartAsync(int? id)
    {
      try
      {
        await _planService.DeleteObrStandartAsync(id);
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

    [HttpPost("obr/filter")]
    public async Task<ActionResult<List<ObrazovatelnyjStandartDto>>> FilterObrStandartAsync(ObrStandartFilterCriterias criterias)
    {
      try
      {
        return Ok(await _planService.FilterObrStandartsAsync(criterias));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}

