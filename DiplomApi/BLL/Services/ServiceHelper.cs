using AutoMapper;
using BLL.Interfaces;
using DAL.DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class ServiceHelper : IServiceHelper
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public ServiceHelper(ApplicationContext applicationContext, IMapper mapper)
    {
      _context = applicationContext;
      _mapper = mapper;
    }

    public async Task<CiklovayaKomissiya> UpdateCiklovayaKomissiyaAsync(int? id)
    {
      return id.HasValue
        ? await _context.CiklovyeKomissii.FindAsync(id.Value)
        : null;
    }
  }
}
