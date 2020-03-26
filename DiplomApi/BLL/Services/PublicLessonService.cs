using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Common.FilterCriterias;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class PublicLessonService : IPublicLessonService
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public PublicLessonService(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<PublicLessonDto> AddOrUpdateAsync(PublicLessonDto publicLessonDto)
    {
      var toUpdate = _mapper.Map<PublicLesson>(publicLessonDto);

      var teacher = await _context.Teachers
       .FirstOrDefaultAsync(x => x.Id == toUpdate.Teacher.Id);
      toUpdate.Teacher = teacher;

      var disciplina = await _context.UchebnyeDiscipliny
        .FirstOrDefaultAsync(x => x.Id == toUpdate.UchebnayaDisciplina.Id);
      toUpdate.UchebnayaDisciplina = disciplina;

      var group = await _context.Groups
        .FirstOrDefaultAsync(x => x.Id == toUpdate.Group.Id);
      toUpdate.Group = group;

      _context.PublicLessons.Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<PublicLessonDto>(toUpdate);
    }

    public async Task<PlanningPublicLessonDto> AddOrUpdatePlanningPublicLessonAsync(PlanningPublicLessonDto publicLessonDto)
    {
      var toUpdate = _mapper.Map<PlanningPublicLesson>(publicLessonDto);

      var teacher = await _context.Teachers
       .FirstOrDefaultAsync(x => x.Id == toUpdate.Teacher.Id);
      toUpdate.Teacher = teacher;

      _context.PlanningPublicLessons.Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<PlanningPublicLessonDto>(toUpdate);
    }

    public async Task<List<PublicLessonDto>> FilterAsync(PublicLessonFilterCriterias filterCriterias)
    {
      var result = _context.PublicLessons
        .Include(x => x.Teacher)
        .Include(x => x.Group)
        .Include(x => x.UchebnayaDisciplina)
        .AsQueryable();

      if (filterCriterias.GroupsIds?.Count() > 0)
      {
        result = result.Where(x => x.Group != null
                                && filterCriterias.GroupsIds.Contains(x.Group.Id));
      }

      if (filterCriterias.TeachersIds?.Count() > 0)
      {
        result = result.Where(x => x.Teacher != null
                                && filterCriterias.TeachersIds.Contains(x.Teacher.Id));
      }
      if (filterCriterias.SubjectsIds?.Count() > 0)
      {
        result = result.Where(x => x.UchebnayaDisciplina != null
                                && filterCriterias.SubjectsIds.Contains(x.UchebnayaDisciplina.Id));
      }

      if (filterCriterias.BeginDate.HasValue)
      {
        result = result.Where(x => x.Date >= filterCriterias.BeginDate);

      }

      if (filterCriterias.EndDate.HasValue)
      {
        result = result.Where(x => x.Date <= filterCriterias.EndDate);
      }

      return _mapper.Map<List<PublicLessonDto>>(await result.ToListAsync());
    }

    public async Task<List<PublicLessonDto>> GetAllAsync()
    {
      return _mapper.Map<List<PublicLessonDto>>(await _context.PublicLessons
        .Include(x => x.Teacher)
        .Include(x => x.Group)
        .Include(x => x.UchebnayaDisciplina)
        .ToListAsync());
    }

    public async Task<List<PlanningPublicLessonDto>> GetAllPlanningLessonsAsync()
    {
      return _mapper.Map<List<PlanningPublicLessonDto>>(await _context.PlanningPublicLessons
       .Include(x => x.Teacher)
       .ToListAsync());
    }

    public async Task<PublicLessonDto> GetAsync(int? id)
    {
      if (!id.HasValue) return null;

      return _mapper.Map<PublicLessonDto>(await _context.PublicLessons
        .Include(x => x.Group)
        .Include(x => x.Teacher)
        .Include(x => x.UchebnayaDisciplina)
        .FirstOrDefaultAsync(x => x.Id == id.Value));
    }

    public async Task<List<PublicLessonDto>> GetByTeacherAsync(int? id)
    {
      return _mapper.Map<List<PublicLessonDto>>(await _context.PublicLessons
       .Where(x => x.Teacher.Id == id.Value)
       .Include(x => x.Teacher)
       .Include(x => x.Group)
       .Include(x => x.UchebnayaDisciplina)
       .ToListAsync());
    }

    public async Task<PlanningPublicLessonDto> GetPlanningLessonAsync(int? id)
    {
      if (!id.HasValue) return null;

      return _mapper.Map<PlanningPublicLessonDto>(await _context.PlanningPublicLessons
        .Include(x => x.Teacher)
        .FirstOrDefaultAsync(x => x.Id == id.Value));
    }

    public async Task<List<PublicLessonDto>> SearchAsync(string query)
    {
      query = Regex.Replace(query.Trim(), "\\s+", " ").ToLower();

      var lessons = await _context.PublicLessons
        .Where(x => x.Topic.ToLower().Contains(query))
        .ToListAsync();

      return _mapper.Map<List<PublicLessonDto>>(lessons);
    }
  }
}
