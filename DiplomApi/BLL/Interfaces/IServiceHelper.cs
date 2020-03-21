using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
  public interface IServiceHelper
  {
    Task<CiklovayaKomissiya> UpdateCiklovayaKomissiyaAsync(int? id);
  }
}
