using System.Collections.Generic;

namespace DAL.Entities
{
  public class Specialnost : DictionaryModel
  {
    public string Code { get; set; }

    public virtual IList<ObrazovatelnyjStandart> ObrazovatelnyjStandarts { get; set; }
  }
}
