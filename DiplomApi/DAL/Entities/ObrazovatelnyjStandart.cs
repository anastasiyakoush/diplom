using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
  public class ObrazovatelnyjStandart
  {
    public int Id { get; set; }
    public string RegistarcionnyjNomer { get; set; }
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }
    public string Link { get; set; }

    public virtual Specialnost Specialnost { get; set; }
    public virtual IList<TipovojUchebnyjPlan> TipovojUchebnyjPlans { get; set; }

  }
}
