using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using Common.FilterCriterias;
using DAL.DAL;
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
      return _mapper.Map<List<PublicLessonDto>>(await _context.PublicLessons.ToListAsync());
    }

    public async Task<PublicLessonDto> GetAsync(int? id)
    {
      if (!id.HasValue) return null;

      return _mapper.Map<PublicLessonDto>(await _context.PublicLessons.FindAsync(id.Value));
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
