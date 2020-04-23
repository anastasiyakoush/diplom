using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Common.FilterCriterias;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class PlanService : IPlanService
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public PlanService(ApplicationContext applicationContext, IMapper mapper)
    {
      _context = applicationContext;
      _mapper = mapper;
    }

    public async Task<ObrazovatelnyjStandartDto> AddOrUpdateObrStandrtAsync(ObrazovatelnyjStandartDto obrazovatelnyjStandartDto)
    {
      var toUpdate = _mapper.Map<ObrazovatelnyjStandart>(obrazovatelnyjStandartDto);

      var dependency = await _context.Specialnosti
       .FirstOrDefaultAsync(x => x.Id == toUpdate.Specialnost.Id);
      toUpdate.Specialnost = dependency;

      _context.ObrazovatelnyeStandarty.Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<ObrazovatelnyjStandartDto>(toUpdate);
    }

    public async Task<TipovojUchebnyjPlanDto> AddOrUpdateTipovoyPlanAsync(TipovojUchebnyjPlanDto tipovojUchebnyjPlanDto)
    {
      var toUpdate = _mapper.Map<TipovojUchebnyjPlan>(tipovojUchebnyjPlanDto);

      var dependency = await _context.ObrazovatelnyeStandarty
        .FirstOrDefaultAsync(x => x.Id == toUpdate.ObrazovatelnyjStandart.Id);
      toUpdate.ObrazovatelnyjStandart = dependency;

      _context.TipovyeUchebnyePlany.Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<TipovojUchebnyjPlanDto>(toUpdate);
    }

    public async Task<UchebnyjPlanDto> AddOrUpdateUchebnyiPlanAsync(UchebnyjPlanDto uchebnyjPlanDto)
    {
      var toUpdate = _mapper.Map<UchebnyjPlan>(uchebnyjPlanDto);

      var dependency = await _context.TipovyeUchebnyePlany
       .FirstOrDefaultAsync(x => x.Id == toUpdate.TipovojUchebnyjPlan.Id);
      toUpdate.TipovojUchebnyjPlan = dependency;

      _context.UchebnyePlany.Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<UchebnyjPlanDto>(toUpdate);
    }

    public async Task DeleteObrStandartAsync(int? id)
    {
      if (!id.HasValue) throw new ArgumentNullException();

      var entity = await _context.ObrazovatelnyeStandarty.FindAsync(id.Value);

      if (entity is null) throw new ArgumentNullException();

      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteTipovoyPlanAsync(int? id)
    {
      if (!id.HasValue) throw new ArgumentNullException();

      var entity = await _context.TipovyeUchebnyePlany.FindAsync(id.Value);

      if (entity is null) throw new ArgumentNullException();

      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteUchebnyiPlanAsync(int? id)
    {
      if (!id.HasValue) throw new ArgumentNullException();

      var entity = await _context.UchebnyePlany.FindAsync(id.Value);

      if (entity is null) throw new ArgumentNullException();

      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<List<ObrazovatelnyjStandartDto>> FilterObrStandartsAsync(ObrStandartFilterCriterias filterCriterias)
    {
      var result = _context.ObrazovatelnyeStandarty.Include(x => x.Specialnost).AsQueryable();

      if (!string.IsNullOrEmpty(filterCriterias?.RegNumber))
      {
        result = result.Where(x =>
        x.RegistarcionnyjNomer.ToLower().Contains(filterCriterias.RegNumber.ToLower()));
      }

      if (filterCriterias.SpecialnostId.HasValue)
      {
        result = result.Where(x => x.Specialnost.Id == filterCriterias.SpecialnostId);
      }

      if (filterCriterias.BeginDate.HasValue)
      {
        result = result.Where(x => x.Date >= filterCriterias.BeginDate);

      }

      if (filterCriterias.EndDate.HasValue)
      {
        result = result.Where(x => x.Date <= filterCriterias.EndDate);
      }

      return _mapper.Map<List<ObrazovatelnyjStandartDto>>(await result.ToListAsync());
    }

    public async Task<List<TipovojUchebnyjPlanDto>> FilterTipovyePlany(TipovojPlanFilterCriterias filterCriterias)
    {
      var result = _context.TipovyeUchebnyePlany.Include(x => x.ObrazovatelnyjStandart).AsQueryable();

      if (!string.IsNullOrEmpty(filterCriterias?.RegNumber))
      {
        result = result.Where(x =>
        x.RegistarcionnyjNomer.ToLower().Contains(filterCriterias.RegNumber.ToLower()));
      }

      if (filterCriterias.ObrStandartId.HasValue)
      {
        result = result.Where(x => x.ObrazovatelnyjStandart.Id == filterCriterias.ObrStandartId);
      }

      if (filterCriterias.BeginDate.HasValue)
      {
        result = result.Where(x => x.Date >= filterCriterias.BeginDate);

      }

      if (filterCriterias.EndDate.HasValue)
      {
        result = result.Where(x => x.Date <= filterCriterias.EndDate);
      }

      return _mapper.Map<List<TipovojUchebnyjPlanDto>>(await result.ToListAsync());
    }

    public async Task<List<UchebnyjPlanDto>> FilterUchebnyePlany(UchebnyiPlanFilterCriterias filterCriterias)
    {
      var result = _context.UchebnyePlany.Include(x => x.TipovojUchebnyjPlan).Include(x => x.Groups).AsQueryable();

      if (!string.IsNullOrEmpty(filterCriterias?.RegNumber))
      {
        result = result.Where(x =>
        x.RegistarcionnyjNomer.ToLower().Contains(filterCriterias.RegNumber.ToLower()));
      }

      if (filterCriterias.TipovoyPlanId.HasValue)
      {
        result = result.Where(x => x.TipovojUchebnyjPlan.Id == filterCriterias.TipovoyPlanId);
      }

      if (filterCriterias.GroupsIds?.Count() > 0)
      {
        result = result.Where(x => x.Groups != null
                                && x.Groups.Any(g => filterCriterias.GroupsIds.Contains(g.Id)));
      }

      if (filterCriterias.BeginDate.HasValue)
      {
        result = result.Where(x => x.Date >= filterCriterias.BeginDate);

      }

      if (filterCriterias.EndDate.HasValue)
      {
        result = result.Where(x => x.Date <= filterCriterias.EndDate);
      }

      return _mapper.Map<List<UchebnyjPlanDto>>(await result.ToListAsync());
    }

    public async Task<IEnumerable<ObrazovatelnyjStandartDto>> GetAllObrStandartsAsync()
    {
      return _mapper.Map<List<ObrazovatelnyjStandartDto>>(await _context.ObrazovatelnyeStandarty.ToListAsync());
    }

    public async Task<IEnumerable<TipovojUchebnyjPlanDto>> GetAllTipovoyPlansAsync()
    {
      return _mapper.Map<List<TipovojUchebnyjPlanDto>>(await _context.TipovyeUchebnyePlany.ToListAsync());
    }

    public async Task<List<UchebnyjPlanDto>> GetAllUchebnyePlansAsync()
    {
      return _mapper.Map<List<UchebnyjPlanDto>>(await _context.UchebnyePlany.ToListAsync());
    }

    public async Task<ObrazovatelnyjStandartDto> GetObrStandartAsync(int? id)
    {
      if (!id.HasValue) return null;

      return _mapper.Map<ObrazovatelnyjStandartDto>(await _context.ObrazovatelnyeStandarty.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id.Value));
    }

    public async Task<TipovojUchebnyjPlanDto> GetTipovoyPlanAsync(int? id)
    {
      if (!id.HasValue) return null;

      return _mapper.Map<TipovojUchebnyjPlanDto>(await _context.TipovyeUchebnyePlany.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id.Value));
    }

    public async Task<UchebnyjPlanDto> GetUchebnyiPlanAsync(int? id)
    {
      if (!id.HasValue) return null;

      return _mapper.Map<UchebnyjPlanDto>(await _context.UchebnyePlany.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id.Value));
    }
  }
}
