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

    Task<UchebnyjPlanDto> AddOrUpdateUchebnyiPlanAsync(UchebnyjPlanDto uchebnyjPlanDto);

    Task DeleteUchebnyiPlanAsync(int? id);

    Task<List<UchebnyjPlanDto>> FilterUchebnyePlany(UchebnyiPlanFilterCriterias filterCriterias);

    Task<IEnumerable<TipovojUchebnyjPlanDto>> GetAllTipovoyPlansAsync();

    Task<TipovojUchebnyjPlanDto> GetTipovoyPlanAsync(int? id);

    Task<TipovojUchebnyjPlanDto> AddOrUpdateTipovoyPlanAsync(TipovojUchebnyjPlanDto tipovojUchebnyjPlanDto);

    Task DeleteTipovoyPlanAsync(int? id);

    Task<List<TipovojUchebnyjPlanDto>> FilterTipovyePlany(TipovojPlanFilterCriterias filterCriterias);

    Task<IEnumerable<ObrazovatelnyjStandartDto>> GetAllObrStandartsAsync();

    Task<ObrazovatelnyjStandartDto> GetObrStandartAsync(int? id);

    Task<ObrazovatelnyjStandartDto> AddOrUpdateObrStandrtAsync(ObrazovatelnyjStandartDto obrazovatelnyjStandartDto);

    Task<List<ObrazovatelnyjStandartDto>> FilterObrStandartsAsync(ObrStandartFilterCriterias filterCriterias);

    Task DeleteObrStandartAsync(int? id);
  }
}
