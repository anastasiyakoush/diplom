using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface IDocumentService
  {
    Task<DocumentDto> AddOrUpdateAsync(DocumentDto t);

    Task DeleteAsync(int? id);

    Task<DocumentDto> GetAsync(int? id);

    Task<List<DocumentDto>> GetAllByDisciplineAsync(int? disciplineId);

    Task<List<DocumentDto>> GetAllByAuthorAsync(int? authorId);
  }
}
