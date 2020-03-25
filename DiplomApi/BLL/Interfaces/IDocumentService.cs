using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface IDocumentService
  {
    //Task<T> GetAsync(int? id);

    Task<string> AddOrUpdateAsync(DocumentDto t);

    // Task DeleteAsync(int? id);

    // Task<List<T>> SearchAsync(string query);
  }
}
