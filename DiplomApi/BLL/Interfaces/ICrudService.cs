using Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface ICrudService<T>
  {
    Task<List<T>> GetAllAsync(params string[] navigationProperties);

    Task<T> GetAsync(int? id, string navProp = null);

    Task<T> AddOrUpdateAsync(T t);

    Task DeleteAsync(int? id);

    Task<List<T>> SearchAsync(string query);
  }
}
