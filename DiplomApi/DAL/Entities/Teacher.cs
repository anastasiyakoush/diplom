using Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
  public class Teacher
  {
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string FatherName { get; set; }
    public Enums.Category Category { get; set; }
    public Enums.Status Status { get; set; }

    public Position Position { get; set; }
    public CiklovayaKomissiya CiklovayaKomissiya { get; set; }
    public virtual IList<DocumentAuthor> DocumentAuthors { get; set; }
  }
}
