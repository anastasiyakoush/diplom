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

namespace DAL.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeachersController : ControllerBase
  {
    private readonly ITeacherService _teacherService;
    private readonly IMapper _mapper;

    public TeachersController(ITeacherService teacherService, IMapper mapper)
    {
      _teacherService = teacherService;
      _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachersAsync()
    {
      try
      {
        return Ok(await _teacherService.GetTeachersAsync());
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
    public async Task<ActionResult<TeacherDto>> GetTeacherAsync(int? id)
    {
      try
      {
        var teacherDto = await _teacherService.GetAsync(id);

        if (teacherDto == null)
        {
          return NotFound();
        }

        return Ok(teacherDto);
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
    public async Task<ActionResult<TeacherDto>> AddOrUpdateTeacherAsync(PostTeacherModel postTeacherModel)
    {
      try
      {
        var updatedTeacherDto =
          await _teacherService.AddOrUpdateTeacherAsync(_mapper.Map<TeacherDto>(postTeacherModel));

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacherAsync(int? id)
    {
      try
      {
        await _teacherService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("{filter}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherDto>> FilterTeachersAsync(TeacherFilterCriterias teacherFilterCriterias)
    {
      try
      {
        return Ok(await _teacherService.FilterTeachersAsync(teacherFilterCriterias));
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
    public async Task<ActionResult<TeacherDto>> SearchTeachersAsync([FromBody]string query)
    {
      try
      {
        return Ok(await _teacherService.SearchTeachersAsync(query));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
