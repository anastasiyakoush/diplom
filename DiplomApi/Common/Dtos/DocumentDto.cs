using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
  public class DocumentDto
  {
    public int? Id { get; set; }
    public string Name { get; set; }
    public string RegistarcionnyjNomer { get; set; }
    public DateTime Date { get; set; }
    public string Link { get; set; }
    public DocumentTypeDto DocumentType { get; set; }
    public UchebnayaDisciplinaDto UchebnayaDisciplina { get; set; }
    public List<TeacherDto> Authors { get; set; }
  }
}
