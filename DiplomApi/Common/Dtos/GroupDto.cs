namespace Common.Dtos
{
  public class GroupDto : DictionaryModelDto
  {
    public int? UchebnyjPlanId { get; set; }

    public UchebnyjPlanDto UchebnyjPlan { get; set; }
  }
}
