using Common.Dtos;
using Common.FilterCriterias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface IPublicLessonService
  {
    Task<List<PublicLessonDto>> GetAllAsync();

    Task<PublicLessonDto> GetAsync(int? id);

    Task<List<PublicLessonDto>> FilterAsync(PublicLessonFilterCriterias filterCriterias);

    Task<List<PublicLessonDto>> SearchAsync(string query);
  }
}
