using System;

namespace Common.FilterCriterias
{
  public class SubjectFilterCriterias
  {
    public string RegNumber { get; set; }
    public int? SpecialnostId { get; set; }
    public int? UchebnyiPlanId { get; set; }
    public int Component { get; set; }
    public int? LRStart { get; set; }
    public int? LREnd { get; set; }
    public int? PRStart { get; set; }
    public int? PREnd { get; set; }
    public int? KPStart { get; set; }
    public int? KPEnd { get; set; }
  }
}