using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
  public class Group
  {
    public int Id { get; set; }
    public string Number { get; set; }

    public virtual UchebnyjPlan UchebnyjPlan { get; set; }
    [Required]
    public virtual Specialnost Specialnost { get; set; }
  }
}
