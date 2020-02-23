using BLL.Interfaces;
using Common.Dtos;
using DAL.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationContext _context;

        public TeacherService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int? id)
        {
            if (!id.HasValue) return;

            var teacher = await _context.Teachers.FindAsync(id.Value);

            if (teacher is null)
            {
                return;
            }

            _context.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<TeacherDto> GetAsync(int? id)
        {
            if (!id.HasValue) throw;

            var teacher = await _context.Teachers.FindAsync(id.Value);
            var teacherDto = new TeacherDto();

            return teacherDto.SetValues(teacher);



            public Task<IEnumerable<TeacherDto>> GetTeachersAsync()
            {
                throw new NotImplementedException();
            }

            public Task<TeacherDto> UpdateAsync(TeacherDto teacher)
            {
                throw new NotImplementedException();
            }
        }
    }
