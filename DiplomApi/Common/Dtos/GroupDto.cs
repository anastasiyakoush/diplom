using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dtos
{
  public class GroupDto
  {
    public int? Id { get; set; }
    public string Number { get; set; }

    public UchebnyjPlanDto UchebnyjPlan { get; set; }

    public SpecialnostDto Specialnost { get; set; }
  }
}
