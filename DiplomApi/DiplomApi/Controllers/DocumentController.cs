using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiplomApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DocumentController : ControllerBase
  {
    private readonly IDocumentService _documentService;
    private readonly ICrudService<DocumentTypeDto> _docTypeService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public DocumentController(IDocumentService documentService, IMapper mapper, ICrudService<DocumentTypeDto> docTypeService, IConfiguration configuration)
    {
      _documentService = documentService;
      _mapper = mapper;
      _docTypeService = docTypeService;
      _configuration = configuration;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentDto>> AddOrUpdateAsync(DocumentDto documentDto)
    {
      try
      {
        return Ok(await _documentService.AddOrUpdateAsync(documentDto));
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
        var documentType = await _docTypeService.GetAsync(type);
        var documentTypeName = documentType?.Name ?? "default";

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

    [HttpPost("download")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DownloadAsync([FromBody]string url)
    {
      try
      {
        var fileNmae = Path.GetFileName(url);
        if (System.IO.File.Exists(url))
        {
          return PhysicalFile(url, "application/octet-stream", "file");
        }

        return BadRequest("File not found.");
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("discipline/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentDto>> GetAllByDisciplineAsync(int? id)
    {
      try
      {
        return Ok(await _documentService.GetAllByDisciplineAsync(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("author/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DocumentDto>> GetAllByAuthorAsync(int? id)
    {
      try
      {
        return Ok(await _documentService.GetAllByAuthorAsync(id));
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
        await _documentService.DeleteAsync(id);
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


    [HttpGet("{id}")]
    public async Task<ActionResult<PublicLessonDto>> GetAsync(int? id)
    {
      try
      {
        var doc = await _documentService.GetAsync(id);

        if (doc == null)
        {
          return NotFound();
        }

        return Ok(doc);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
