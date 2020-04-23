using System.Collections.Generic;

namespace DAL.Entities
{
  public class Position : DictionaryModel
  {
    public virtual IList<Teacher> Teachers { get; set; }
  }
}
