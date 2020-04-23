using System;
using static Common.Enums;

namespace DiplomApi.PostModels
{
  public class PostPlanModel
  {
    public int Id { get; set; }

    public string RegistarcionnyjNomer { get; set; }

    public DateTime? Date { get; set; }

    public int? DependencyId { get; set; }

    public PlanType PlanType { get; set; }

    public string Link { get; set; }
  }
}
