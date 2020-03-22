using AutoMapper;
using DAL.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
  public class ConfigurationService
  {
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public ConfigurationService(ApplicationContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
  }
}
