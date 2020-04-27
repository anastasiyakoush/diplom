using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
  public class ComparableLessonsDto
  {
    public TeacherDto Teacher { get; set; }
    public int Month { get; set; }
    public DateTime? Date { get; set; }
    public string Topic { get; set; }
  }
}
