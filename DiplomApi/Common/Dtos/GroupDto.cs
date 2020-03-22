namespace Common.Dtos
{
  public class GroupDto : DictionaryModelDto
  {
    public int? SpecialnostId { get; set; }
    public int? UchebnyjPlanId { get; set; }

    public UchebnyjPlanDto UchebnyjPlan { get; set; }

    public SpecialnostDto Specialnost { get; set; }
  }
}
