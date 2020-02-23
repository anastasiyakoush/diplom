using Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetTeachersAsync();
        Task<TeacherDto> GetAsync(int? id);
        Task<TeacherDto> UpdateAsync(TeacherDto teacher);
        Task DeleteAsync(int? id);
    }
}
