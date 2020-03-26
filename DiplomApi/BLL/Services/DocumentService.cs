using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class DocumentService : IDocumentService
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public DocumentService(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<DocumentDto> AddOrUpdateAsync(DocumentDto t)
    {
      var toUpdate = _mapper.Map<Document>(t);

      toUpdate.UchebnayaDisciplina = await _context.UchebnyeDiscipliny
       .FirstOrDefaultAsync(x => x.Id == toUpdate.UchebnayaDisciplina.Id);

      toUpdate.DocumentType = await _context.DocumentTypes
      .FirstOrDefaultAsync(x => x.Id == toUpdate.DocumentType.Id);

      var authorsIds = t.Authors.Select(x => x.Id);

      var authors = _context.Teachers.Where(x => authorsIds.Contains(x.Id))
        .Select(x => new DocumentAuthor
        {
          Teacher = x,
          Document = toUpdate
        }).ToList();

      //_context.DocumentsAuthors.UpdateRange(authors);

      toUpdate.DocumentAuthors = authors;
      _context.Documents.Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<DocumentDto>(toUpdate);
    }

    public Task DeleteAsync(int? id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<DocumentDto>> GetAllByAuthorAsync(int? authorId)
    {
      return _mapper.Map<List<DocumentDto>>(await _context.Documents
        .Where(x => x.DocumentAuthors.Select(c => c.TeacherId).Contains(authorId.Value))
        .Include(x => x.DocumentType)
        .Include(x => x.UchebnayaDisciplina)
        .Include(x => x.DocumentAuthors).ThenInclude(x => x.Teacher)
        .ToListAsync());
    }

    public async Task<List<DocumentDto>> GetAllByDisciplineAsync(int? disciplineId)
    {
      var t = await _context.Documents
        .Where(x => x.UchebnayaDisciplina.Id == disciplineId.Value)
        .Include(x => x.DocumentType)
        .Include(x => x.UchebnayaDisciplina)
        .Include(x => x.DocumentAuthors).ThenInclude(x => x.Teacher)
        .ToListAsync();
      return _mapper.Map<List<DocumentDto>>(t);
    }
  }
}
