using System;
using System.Collections.Generic;

namespace Common.Dtos
{
  public class UchebnyjPlanDto : PlanDto
  {
    public List<GroupDto> Groups { get; set; }

    public TipovojUchebnyjPlanDto TipovojUchebnyjPlan { get; set; }
  }
}
