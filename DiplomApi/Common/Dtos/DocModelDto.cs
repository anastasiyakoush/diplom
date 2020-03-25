using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
  public class DocModelDto
  {
    public string Name { get; set; }
    public string RegistarcionnyjNomer { get; set; }
    public DateTime? Date { get; set; }
    public List<int> Authors { get; set; }
    public int? DocumentType { get; set; }
  }
}
