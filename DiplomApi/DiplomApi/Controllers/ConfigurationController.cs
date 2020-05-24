using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Common;
using Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ConfigurationController : ControllerBase
  {
    private readonly ICrudService<SpecialnostDto> _specialnostService;
    private readonly ICrudService<GroupDto> _groupService;
    private readonly ICrudService<CiklovayaKomissiyaDto> _ckService;
    private readonly ICrudService<DocumentTypeDto> _docTypeService;
    private readonly ICrudService<PositionDto> _positionService;
    private readonly IMapper _mapper;
    private readonly IPlanService _planService;

    public ConfigurationController(
      IMapper mapper,
      ICrudService<SpecialnostDto> specialnostService,
      ICrudService<GroupDto> groupService,
      ICrudService<CiklovayaKomissiyaDto> ckService,
      ICrudService<DocumentTypeDto> docTypeService,
      ICrudService<PositionDto> positionService,
      IPlanService planService)
    {
      _mapper = mapper;
      _ckService = ckService;
      _specialnostService = specialnostService;
      _groupService = groupService;
      _docTypeService = docTypeService;
      _positionService = positionService;
      _planService = planService;
    }

    [HttpGet("specialnost")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SpecialnostDto>>> GetAllSpecialnostAsync()
    {
      try
      {
        return Ok(await _specialnostService.GetAllAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("specialnost/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecialnostDto>> GetSpecialnostAsync(int? id)
    {
      try
      {
        var result = await _specialnostService.GetAsync(id);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("specialnost")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecialnostDto>> AddOrUpdateSpecialnostAsync(SpecialnostDto specialnostDto)
    {
      try
      {
        var result = await _specialnostService.AddOrUpdateAsync(specialnostDto);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("specialnost/{id}")]
    public async Task<IActionResult> DeleteSpecialnostAsync(int? id)
    {
      try
      {
        await _specialnostService.DeleteAsync(id);
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

    [HttpPost("specialnost/search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<SpecialnostDto>>> SearchSpecialnostAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _specialnostService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("doctype")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DocumentTypeDto>>> GetAllDocumentTypesAsync()
    {
      try
      {
        return Ok(await _docTypeService.GetAllAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("doctype/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentTypeDto>> GetDocumentTypeAsync(int? id)
    {
      try
      {
        var result = await _docTypeService.GetAsync(id);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("doctype")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentTypeDto>> AddOrUpdateDocumentTypeAsync(DocumentTypeDto documentTypeDto)
    {
      try
      {
        var result = await _docTypeService.AddOrUpdateAsync(documentTypeDto);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("doctype/{id}")]
    public async Task<IActionResult> DeleteDocumentTypeAsync(int? id)
    {
      try
      {
        await _docTypeService.DeleteAsync(id);
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

    [HttpPost("doctype/search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<DocumentTypeDto>>> SearchDocumentTypeAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _docTypeService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [HttpGet("group")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetAllGroupAsync()
    {
      try
      {
        var groups = await _groupService.GetAllAsync("UchebnyjPlan");
        return Ok(groups);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("group/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GroupDto>> GetGroupAsync(int? id)
    {
      try
      {
        var result = await _groupService.GetAsync(id);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("group")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GroupDto>> AddOrUpdateGroupAsync(GroupDto groupDto)
    {
      try
      {
        if (groupDto.UchebnyjPlanId.HasValue || groupDto.UchebnyjPlan != null)
        {
          groupDto.UchebnyjPlan = await _planService.GetUchebnyiPlanAsync(groupDto.UchebnyjPlanId);
          groupDto.UchebnyjPlanId = groupDto.UchebnyjPlan is null ? null : groupDto.UchebnyjPlanId;
        }

        var result = await _groupService.AddOrUpdateAsync(groupDto);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("group/{id}")]
    public async Task<IActionResult> DeleteGroupAsync(int? id)
    {
      try
      {
        await _groupService.DeleteAsync(id);
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

    [HttpPost("group/search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<GroupDto>>> SearchGroupAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _groupService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [HttpGet("ck")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CiklovayaKomissiyaDto>>> GetAllCiklovayaKomissiyasAsync()
    {
      try
      {
        return Ok(await _ckService.GetAllAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("ck/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiklovayaKomissiyaDto>> GetCiklovayaKomissiyaAsync(int? id)
    {
      try
      {
        var result = await _ckService.GetAsync(id);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("ck")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiklovayaKomissiyaDto>> AddOrUpdateCiklovayaKomissiyaAsync(CiklovayaKomissiyaDto ciklovayaKomissiyaDto)
    {
      try
      {
        var result = await _ckService.AddOrUpdateAsync(ciklovayaKomissiyaDto);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("ck/{id}")]
    public async Task<IActionResult> DeleteCiklovayaKomissiyaAsync(int? id)
    {
      try
      {
        await _ckService.DeleteAsync(id);
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

    [HttpPost("ck/search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<CiklovayaKomissiyaDto>>> SearchCiklovayaKomissiyaAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _ckService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [Authorize]
    [HttpGet("position")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PositionDto>>> GetAllPositionAsync()
    {
      try
      {
        return Ok(await _positionService.GetAllAsync());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [Authorize]
    [HttpGet("position/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PositionDto>> GetPositionAsync(int? id)
    {
      try
      {
        var result = await _positionService.GetAsync(id);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [Authorize(Roles = Roles.Admin)]
    [HttpPost("position")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiklovayaKomissiyaDto>> AddOrUpdatePositionAsync(PositionDto positionDto)
    {
      try
      {
        var result = await _positionService.AddOrUpdateAsync(positionDto);

        if (result is null)
        {
          return NotFound();
        }

        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("position/{id}")]
    public async Task<IActionResult> DeletePositionAsync(int? id)
    {
      try
      {
        await _positionService.DeleteAsync(id);
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
    [Authorize]
    [HttpPost("position/search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<PositionDto>>> SearchPositionAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _positionService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
