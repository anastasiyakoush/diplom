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

    Task<List<PlanningPublicLessonDto>> GetAllPlanningLessonsAsync();

    Task<PublicLessonDto> GetAsync(int? id);

    Task<List<PublicLessonDto>> GetByTeacherAsync(int? id);

    Task<PlanningPublicLessonDto> GetPlanningLessonAsync(int? id);

    Task<List<PublicLessonDto>> FilterAsync(PublicLessonFilterCriterias filterCriterias);

    Task<List<PublicLessonDto>> SearchAsync(string query);

    Task<PublicLessonDto> AddOrUpdateAsync(PublicLessonDto publicLessonDto);

    Task<PlanningPublicLessonDto> AddOrUpdatePlanningPublicLessonAsync(PlanningPublicLessonDto publicLessonDto);
  }
}
