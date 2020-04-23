using System.Collections.Generic;

namespace DAL.Entities
{
  public class DocumentType : DictionaryModel
  {
    public virtual IList<Document> Documents { get; set; }
  }
}
