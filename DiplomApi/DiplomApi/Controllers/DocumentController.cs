using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using DiplomApi.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DocumentController : ControllerBase
  {
    private readonly IDocumentService _documentService;
    private readonly IMapper _mapper;

    public DocumentController(IDocumentService documentService, IMapper mapper)
    {
      _documentService = documentService;
      _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TeacherDto>> AddAsync(PostDocumentModel postDocumentModel)
    {
      try
      {

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}
