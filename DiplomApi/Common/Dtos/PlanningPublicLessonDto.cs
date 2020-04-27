using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
  public class PlanningPublicLessonDto
  {
    public int? Id { get; set; }
    public bool Status { get; set; }
    public int Month { get; set; }

    public TeacherDto Teacher { get; set; }
  }
}
