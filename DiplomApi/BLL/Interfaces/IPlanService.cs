using Common.Dtos;
using Common.FilterCriterias;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface IPlanService
  {
    Task<List<UchebnyjPlanDto>> GetAllUchebnyePlansAsync();

    Task<UchebnyjPlanDto> GetUchebnyiPlanAsync(int? id);

    Task<List<UchebnyjPlanDto>> FilterUchebnyePlany(UchebnyiPlanFilterCriterias filterCriterias);

    //Task<List<UchebnyjPlanDto>> SearchUchebnyiPlanAsync(string query);

    //Task<IEnumerable<UchebnyjPlanDto>> GetAllTipovoyPlansAsync();

    //Task<UchebnyjPlanDto> GetTipovoyPlanAsync(int? id);

    //Task<UchebnyjPlanDto> AddOrUpdateTipovoyPlanAsync(TipovojUchebnyjPlanDto tipovojUchebnyjPlanDto);

    //Task DeleteTipovoyPlanAsync(int? id);

    //Task<List<UchebnyjPlanDto>> SearchTipovoyPlanAsync(string query);

    //Task<IEnumerable<UchebnyjPlanDto>> GetAllUchebnyePlansAsync();

    //Task<UchebnyjPlanDto> GetUchebnyiPlanAsync(int? id);

    Task<UchebnyjPlanDto> AddOrUpdateUchebnyiPlanAsync(UchebnyjPlanDto uchebnyjPlanDto);

    Task DeleteUchebnyiPlanAsync(int? id);

    //Task<List<UchebnyjPlanDto>> FilterUchebnyiPlanAsync(SubjectFilterCriterias subjectFilterCriterias);

    //Task<List<UchebnyjPlanDto>> SearchUchebnyiPlanAsync(string query);
  }
}
