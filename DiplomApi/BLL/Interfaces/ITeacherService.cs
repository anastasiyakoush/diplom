using Common.Dtos;
using Common.FilterCriterias;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface ITeacherService
  {
    Task<IEnumerable<TeacherDto>> GetTeachersAsync();

    Task<TeacherDto> GetAsync(int? id);

    Task<TeacherDto> AddOrUpdateTeacherAsync(TeacherDto teacher);

    Task DeleteAsync(int? id);

    Task<List<TeacherDto>> FilterTeachersAsync(TeacherFilterCriterias teacherFilterCriterias);

    Task<List<TeacherDto>> SearchTeachersAsync(string searchQuery);
  }
}
