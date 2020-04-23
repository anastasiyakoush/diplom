using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
  public class UchebnyjPlan
  {
    public int Id { get; set; }
    public string RegistarcionnyjNomer { get; set; }
    [Column(TypeName = "date")]
    public DateTime Date { get; set; }
    public string Link { get; set; }

    public virtual IList<Group> Groups { get; set; }
    public virtual IList<UchebnayaDisciplina> UchebnayaDisciplinas { get; set; }

    public virtual TipovojUchebnyjPlan TipovojUchebnyjPlan { get; set; }
  }
}
