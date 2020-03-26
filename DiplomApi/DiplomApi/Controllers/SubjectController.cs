using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Common.FilterCriterias;
using DiplomApi.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SubjectController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ISubjectService _subjectService;

    public SubjectController(IMapper mapper, ISubjectService subjectService)
    {
      _mapper = mapper;
      _subjectService = subjectService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UchebnayaDisciplinaDto>>> GetAllAsync()
    {
      try
      {
        return Ok(await _subjectService.GetAllAsync());
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
    public async Task<ActionResult<UchebnayaDisciplinaDto>> GetAsync(int? id)
    {
      try
      {
        var uchebnayaDisciplinaDto = await _subjectService.GetAsync(id);

        if (uchebnayaDisciplinaDto == null)
        {
          return NotFound();
        }

        return Ok(uchebnayaDisciplinaDto);
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
    public async Task<ActionResult<UchebnayaDisciplinaDto>> AddOrUpdateAsync(UchebnayaDisciplinaDto uchebnayaDisciplinaDto)
    {
      try
      {
        var updatedUchebnayaDisciplinaDto =
          await _subjectService.AddOrUpdateAsync(uchebnayaDisciplinaDto);

        if (updatedUchebnayaDisciplinaDto == null)
        {
          return NotFound();
        }

        return Ok(updatedUchebnayaDisciplinaDto);
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
        await _subjectService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("filter")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<TeacherDto>>> FilterAsync(SubjectFilterCriterias subjectFilterCriterias)
    {
      try
      {
        return Ok(await _subjectService.FilterAsync(subjectFilterCriterias));
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
    public async Task<ActionResult<List<UchebnayaDisciplinaDto>>> SearchAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _subjectService.SearchAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
