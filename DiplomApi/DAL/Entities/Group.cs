using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
  public class Group : DictionaryModel
  {
    //public int SpecialnostId { get; set; }
    public int? UchebnyjPlanId { get; set; }

    public virtual UchebnyjPlan UchebnyjPlan { get; set; }
   // public virtual Specialnost Specialnost { get; set; }
    public virtual IList<PublicLesson> PublicLessons { get; set; }
  }
}
