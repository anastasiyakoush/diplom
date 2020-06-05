using AutoMapper;
using BLL.Interfaces;
using Common.Dtos;
using DAL.DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class CrudService<T, V> : ICrudService<T>
    where V : DictionaryModel
    where T : DictionaryModelDto
  {
    private readonly DbContext _context;
    private readonly IMapper _mapper;

    public CrudService(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<T> AddOrUpdateAsync(T t)
    {
      if (t.Id.HasValue
        && await _context.Set<V>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == t.Id.Value) is null)
      {
        return null;
      }

      var toUpdate = _mapper.Map<V>(t);

      _context.Set<V>().Update(toUpdate);

      await _context.SaveChangesAsync();

      return _mapper.Map<T>(toUpdate);
    }

    public async Task DeleteAsync(int? id)
    {
      if (!id.HasValue) throw new ArgumentNullException();

      var entity = await _context.Set<V>().FindAsync(id.Value);

      if (entity is null) throw new ArgumentNullException();

      _context.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync(params string[] navigationProperties)
    {
      var entities = _context.Set<V>().AsQueryable();

      foreach (var item in navigationProperties)
      {
        entities = entities.Include(item);
      }

      return _mapper.Map<List<T>>(await entities.ToListAsync());
    }

    public async Task<T> GetAsync(int? id, string navProp = null)
    {
      if (!id.HasValue) return null;

      var ctx = _context.Set<V>().AsNoTracking();
      if (!string.IsNullOrEmpty(navProp))
      {
        ctx = _context.Set<V>().Include(navProp).AsNoTracking();
      }

      return _mapper.Map<T>(await ctx.FirstOrDefaultAsync(x => x.Id == id.Value));
    }

    public async Task<List<T>> SearchAsync(string query)
    {
      query = Regex.Replace(query.Trim(), "\\s+", " ").ToLower();

      var result = await _context.Set<V>()
        .Where(x => x.Name.ToLower().Contains(query))
        .ToListAsync();

      return _mapper.Map<List<T>>(result);
    }
  }
}
