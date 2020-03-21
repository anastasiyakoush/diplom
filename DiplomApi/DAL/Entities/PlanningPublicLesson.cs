using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
  public class PlanningPublicLesson
  {
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public bool Status { get; set; }
    public DateTime ExpectedDate { get; set; }

    public virtual Teacher Teacher { get; set; }
  }
}
