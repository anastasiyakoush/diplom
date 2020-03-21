using System;
using System.Collections.Generic;
using System.Text;

namespace Common.FilterCriterias
{
  public class PublicLessonFilterCriterias
  {
    public List<int> GroupsIds { get; set; }
    public List<int> TeachersIds { get; set; }
    public List<int> SubjectsIds { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
  }
}
