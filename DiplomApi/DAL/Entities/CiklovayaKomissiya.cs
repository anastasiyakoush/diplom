using System.Collections.Generic;

namespace DAL.Entities
{
  public class CiklovayaKomissiya : DictionaryModel
  {
    public virtual IList<Teacher> Teachers { get; set; }
    public virtual IList<UchebnayaDisciplina> UchebnayaDisciplinas { get; set; }
  }
}
