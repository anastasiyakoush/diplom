using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Common.FilterCriterias;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Common.Enums;

namespace BLL.Services
{
  public class SubjectService : ISubjectService
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public SubjectService(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<UchebnayaDisciplinaDto> AddOrUpdateAsync(UchebnayaDisciplinaDto uchebnayaDisciplinaDto)
    {
      var toUpdate = _mapper.Map<UchebnayaDisciplina>(uchebnayaDisciplinaDto);

      await UpdateUchebnyiPlanAsync(toUpdate);
      await UpdateCiklovayaKomissiyaAsync(toUpdate);

      if (uchebnayaDisciplinaDto.Id.HasValue)
      {
        _context.UchebnyeDiscipliny.Update(toUpdate);
      }
      else
      {
        await _context.UchebnyeDiscipliny.AddAsync(toUpdate);
      }

      await _context.SaveChangesAsync();

      return _mapper.Map<UchebnayaDisciplinaDto>(toUpdate);
    }

    public async Task DeleteAsync(int? id)
    {
      if (!id.HasValue) throw new ArgumentNullException();

      var uchebnayaDisciplina = await _context.UchebnyeDiscipliny.FindAsync(id.Value);

      if (uchebnayaDisciplina is null) throw new ArgumentNullException();

      _context.Remove(uchebnayaDisciplina);
      await _context.SaveChangesAsync();
    }

    public async Task<List<UchebnayaDisciplinaDto>> FilterAsync(SubjectFilterCriterias filterCriterias)
    {
      var result = _context.UchebnyeDiscipliny
                          .Include(x => x.UchebnyjPlan)
                            .ThenInclude(x => x.TipovojUchebnyjPlan)
                            .ThenInclude(x => x.ObrazovatelnyjStandart)
                            .ThenInclude(x => x.Specialnost)
                          .Include(x => x.CiklovayaKomissiya)
                          .AsQueryable();
      if (filterCriterias.UchebnyiPlanId.HasValue)
      {
        result = result.Where(x => x.UchebnyjPlan.Id == filterCriterias.UchebnyiPlanId);
      }

      if (filterCriterias.SpecialnostId.HasValue)
      {
        result = result.Where(x => x.UchebnyjPlan.TipovojUchebnyjPlan.ObrazovatelnyjStandart.Specialnost.Id == filterCriterias.SpecialnostId);
      }

      if (filterCriterias.Component.HasValue)
      {
        result = result.Where(x => x.Component == filterCriterias.Component);
      }

      if (filterCriterias.LRStart.HasValue)
      {
        result = result.Where(x => x.Laboratornye >= filterCriterias.LRStart);
      }

      if (filterCriterias.LREnd.HasValue)
      {
        result = result.Where(x => x.Laboratornye <= filterCriterias.LREnd);
      }

      if (filterCriterias.KPStart.HasValue)
      {
        result = result.Where(x => x.KursovoeProectirovanie >= filterCriterias.KPStart);
      }

      if (filterCriterias.KPEnd.HasValue)
      {
        result = result.Where(x => x.KursovoeProectirovanie <= filterCriterias.KPEnd);
      }

      if (filterCriterias.PRStart.HasValue)
      {
        result = result.Where(x => x.Practika >= filterCriterias.PRStart);
      }

      if (filterCriterias.PREnd.HasValue)
      {
        result = result.Where(x => x.Practika <= filterCriterias.PREnd);
      }

      if (filterCriterias.AllStart.HasValue)
      {
        result = result.Where(x => x.All >= filterCriterias.AllStart);
      }

      if (filterCriterias.AllEnd.HasValue)
      {
        result = result.Where(x => x.All <= filterCriterias.AllEnd);
      }

      return _mapper.Map<List<UchebnayaDisciplinaDto>>(await result.ToListAsync());
    }

    public async Task<IEnumerable<UchebnayaDisciplinaDto>> GetAllAsync()
    {
      var uchebnayaDisciplinas = await _context.UchebnyeDiscipliny
       .Include(x => x.CiklovayaKomissiya)
       .Include(x => x.UchebnyjPlan)
       .ToListAsync();

      return _mapper.Map<IEnumerable<UchebnayaDisciplinaDto>>(uchebnayaDisciplinas);
    }

    public async Task<UchebnayaDisciplinaDto> GetAsync(int? id)
    {
      if (!id.HasValue) return null;

      var uchebnayaDisciplina = await _context.UchebnyeDiscipliny.Include(x => x.CiklovayaKomissiya).Include(x => x.UchebnyjPlan).FirstOrDefaultAsync(x => x.Id == id.Value);

      return _mapper.Map<UchebnayaDisciplinaDto>(uchebnayaDisciplina);
    }

    public async Task<List<UchebnayaDisciplinaDto>> SearchAsync(string query)
    {
      query = Regex.Replace(query.Trim(), "\\s+", " ").ToLower();

      var uchebnayaDisciplinas = await _context.UchebnyeDiscipliny
        .Where(x => x.Name.ToLower().Contains(query))
        .ToListAsync();

      return _mapper.Map<List<UchebnayaDisciplinaDto>>(uchebnayaDisciplinas);
    }

    private async Task UpdateCiklovayaKomissiyaAsync(UchebnayaDisciplina uchebnayaDisciplina)
    {
      uchebnayaDisciplina.CiklovayaKomissiya
          = uchebnayaDisciplina?.CiklovayaKomissiya?.Id is null
          ? null
          : await _context.CiklovyeKomissii.FindAsync(uchebnayaDisciplina.CiklovayaKomissiya.Id);
    }

    private async Task UpdateUchebnyiPlanAsync(UchebnayaDisciplina uchebnayaDisciplina)
    {
      uchebnayaDisciplina.UchebnyjPlan
          = uchebnayaDisciplina?.UchebnyjPlan?.Id is null
          ? null
          : await _context.UchebnyePlany.FindAsync(uchebnayaDisciplina.UchebnyjPlan.Id);
    }
  }
}
