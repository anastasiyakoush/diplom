using System;
using System.Collections.Generic;

namespace Common.FilterCriterias
{
  public class UchebnyiPlanFilterCriterias
  {
    public string RegNumber { get; set; }
    public int? TipovoyPlanId { get; set; }
    public List<int> GroupsIds { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
  }
}
