using System;
using System.Collections.Generic;

namespace DiplomApi.PostModels
{
  public class PostDocumentModel
  {
    public string Name { get; set; }
    public string RegistarcionnyjNomer { get; set; }
    public DateTime? Date { get; set; }
    public List<int> Authors { get; set; }
    public int? DocumentType { get; set; }
  }
}
