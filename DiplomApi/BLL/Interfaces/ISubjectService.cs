using Common.Dtos;
using Common.FilterCriterias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface ISubjectService
  {
    Task<IEnumerable<UchebnayaDisciplinaDto>> GetAllAsync();

    Task<UchebnayaDisciplinaDto> GetAsync(int? id);

    Task<UchebnayaDisciplinaDto> AddOrUpdateAsync(UchebnayaDisciplinaDto uchebnayaDisciplinaDto);

    Task DeleteAsync(int? id);

    Task<List<UchebnayaDisciplinaDto>> FilterAsync(SubjectFilterCriterias subjectFilterCriterias);

    Task<List<UchebnayaDisciplinaDto>> SearchAsync(string query);
  }
}
