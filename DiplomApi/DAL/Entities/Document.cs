using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
  public class Document
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string RegistarcionnyjNomer { get; set; }
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }
    public string Link { get; set; }

    [Required]
    public DocumentType DocumentType { get; set; }
    [Required]
    public UchebnayaDisciplina UchebnayaDisciplina { get; set; }
    public List<DocumentAuthor> DocumentAuthors { get; set; }
  }
}
