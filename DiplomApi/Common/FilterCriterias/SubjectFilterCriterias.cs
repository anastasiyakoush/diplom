using System;
using static Common.Enums;

namespace Common.FilterCriterias
{
  public class SubjectFilterCriterias
  {
    public int? SpecialnostId { get; set; }
    public int? UchebnyiPlanId { get; set; }
    public Component? Component { get; set; }
    public int? LRStart { get; set; }
    public int? LREnd { get; set; }
    public int? PRStart { get; set; }
    public int? PREnd { get; set; }
    public int? KPStart { get; set; }
    public int? KPEnd { get; set; }
    public int? AllStart { get; set; }
    public int? AllEnd { get; set; }
  }
}
