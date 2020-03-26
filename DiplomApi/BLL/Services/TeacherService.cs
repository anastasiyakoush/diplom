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

namespace BLL.Services
{
  public class TeacherService : ITeacherService
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public TeacherService(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task DeleteAsync(int? id)
    {
      if (!id.HasValue) throw new ArgumentNullException("Указанный преподаватель не существует");

      var teacher = await _context.Teachers.FindAsync(id.Value);

      if (teacher is null) throw new ArgumentNullException("Указанный преподаватель не существует");

      _context.Remove(teacher);
      await _context.SaveChangesAsync();
    }

    public async Task<TeacherDto> GetAsync(int? id)
    {
      if (!id.HasValue) return null;

      var teacher = await _context.Teachers.Include(x => x.CiklovayaKomissiya).Include(x => x.Position).FirstOrDefaultAsync(x => x.Id == id.Value);

      return _mapper.Map<TeacherDto>(teacher);
    }


    public async Task<IEnumerable<TeacherDto>> GetTeachersAsync()
    {
      var teachers = await _context.Teachers
        .Include(x => x.CiklovayaKomissiya)
        .Include(x => x.Position)
        .ToListAsync();

      return _mapper.Map<IEnumerable<TeacherDto>>(teachers);
    }

    public async Task<TeacherDto> AddOrUpdateTeacherAsync(TeacherDto teacherDto)
    {
      var teacherToUpdate = _mapper.Map<Teacher>(teacherDto);

      await UpdatePositionAsync(teacherToUpdate);
      await UpdateCiklovayaKomissiyaAsync(teacherToUpdate);

      if (teacherDto.Id.HasValue)
      {
        _context.Teachers.Update(teacherToUpdate);
      }
      else
      {
        await _context.Teachers.AddAsync(teacherToUpdate);
      }

      await _context.SaveChangesAsync();

      return _mapper.Map<TeacherDto>(teacherToUpdate);
    }

    public async Task<List<TeacherDto>> FilterTeachersAsync(TeacherFilterCriterias teacherFilterCriterias)
    {
      var teachers = _context.Teachers.Include(x => x.CiklovayaKomissiya).AsQueryable();

      if (teacherFilterCriterias.Category.HasValue)
      {
        teachers = teachers.Where(x => x.Category == teacherFilterCriterias.Category);
      }

      if (teacherFilterCriterias.Status.HasValue)
      {
        teachers = teachers.Where(x => x.Status == teacherFilterCriterias.Status);
      }

      if (teacherFilterCriterias.CiklovayaKomissiya.HasValue)
      {
        teachers = teachers.Where(x => x.CiklovayaKomissiya.Id == teacherFilterCriterias.CiklovayaKomissiya);
      }

      return _mapper.Map<List<TeacherDto>>(await teachers.Include(x => x.Position).ToListAsync());
    }

    public async Task<List<TeacherDto>> SearchTeachersAsync(string searchQuery)
    {
      searchQuery = Regex.Replace(searchQuery.Trim(), "\\s+", " ").ToLower();

      var teachers = searchQuery.Contains(" ")
                   ? _context.Teachers.AsEnumerable()
                             .Where(x => FioContainsSearchQuery(searchQuery, x))
                             .ToList()
                   : await _context.Teachers.Where(x => x.Surname.ToLower().Contains(searchQuery)
                                                     || x.Name.ToLower().Contains(searchQuery)
                                                     || x.FatherName.ToLower().Contains(searchQuery)
                                                     ).ToListAsync();

      return _mapper.Map<List<TeacherDto>>(teachers);
    }

    private async Task UpdatePositionAsync(Teacher teacher)
    {
      teacher.Position
        = teacher?.Position?.Id is null
        ? null
        : await _context.Positions.FindAsync(teacher.Position.Id);
    }

    private async Task UpdateCiklovayaKomissiyaAsync(Teacher teacher)
    {
      teacher.CiklovayaKomissiya
          = teacher?.CiklovayaKomissiya?.Id is null
          ? null
          : await _context.CiklovyeKomissii.FindAsync(teacher.CiklovayaKomissiya.Id);
    }

    private string GetTeacherFio(Teacher teacher)
    {
      return $"{teacher.Surname} {teacher.Name} {teacher.FatherName}";
    }

    private bool FioContainsSearchQuery(string searchQuery, Teacher teacher)
    {
      return GetTeacherFio(teacher).ToLower().Contains(searchQuery);
    }
  }
}
