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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Common.Enums;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlanController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IPlanService _planService;

    public PlanController(IMapper mapper, IPlanService planService)
    {
      _mapper = mapper;
      _planService = planService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<UchebnyjPlanDto>>> GetAllUchebnyePlansAsync()
    {
      try
      {
        return Ok(await _planService.GetAllUchebnyePlansAsync());
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

    [HttpPost("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UploadPlanAsync([FromQuery] int plan)
    {
      try
      {
        var planType = (PlanType)plan;
        var file = Request.Form.Files.FirstOrDefault();
        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var directory = Path.Combine("D:\\DiplomFiles", planType.ToString());

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

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteUchebnyiPlanAsync(int? id)
    //{
    //  try
    //  {
    //    await _planService.DeleteUchebnyiPlanAsync(id);
    //    return Ok();
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    //[HttpPost("search")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<List<UchebnayaDisciplinaDto>>> SearchUchebnyiPlanAsync([FromBody]string query)
    //{
    //  try
    //  {
    //    return Ok(await _planService.SearchUchebnyiPlanAsync(query));
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    //[HttpGet]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<IEnumerable<TipovojUchebnyjPlanDto>>> GetAllTipovojPlansAsync()
    //{
    //  try
    //  {
    //    return Ok(await _planService.GetAllTipovoyPlansAsync());
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    //[HttpGet("{id}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<TipovojUchebnyjPlanDto>> GetTipovojPlanAsync(int? id)
    //{
    //  try
    //  {
    //    var uchebnyjPlanDto = await _planService.GetTipovoyPlanAsync(id);

    //    if (uchebnyjPlanDto == null)
    //    {
    //      return NotFound();
    //    }

    //    return Ok(uchebnyjPlanDto);
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    //[HttpPost]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<TipovojUchebnyjPlanDto>> AddOrUpdateTipovojAsync(PostTipovoyPlanModel postTipovoyPlanModel)
    //{
    //  try
    //  {
    //    var uchebnyjPlanDto =
    //      await _planService.AddOrUpdateTipovoyPlanAsync(_mapper.Map<TipovojUchebnyjPlanDto>(postTipovoyPlanModel));

    //    if (uchebnyjPlanDto == null)
    //    {
    //      return NotFound();
    //    }

    //    return Ok(uchebnyjPlanDto);
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteTipovojAsync(int? id)
    //{
    //  try
    //  {
    //    await _planService.DeleteTipovoyPlanAsync(id);
    //    return Ok();
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}

    //[HttpPost("search")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<List<TipovojUchebnyjPlanDto>>> SearchTipovojAsync([FromBody]string query)
    //{
    //  try
    //  {
    //    return Ok(await _planService.SearchTipovoyPlanAsync(query));
    //  }
    //  catch (Exception ex)
    //  {
    //    return BadRequest(ex.Message);
    //  }
    //}
  }
}

