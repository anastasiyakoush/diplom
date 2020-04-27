using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
  public class PlanningPublicLesson
  {
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public bool Status { get; set; }
    [Range(1, 12)]
    public int Month { get; set; }

    public virtual Teacher Teacher { get; set; }
  }
}
