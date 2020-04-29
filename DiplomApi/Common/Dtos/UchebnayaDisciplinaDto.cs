namespace Common.Dtos
{
  public class UchebnayaDisciplinaDto
  {
    public int? Id { get; set; }

    public string Name { get; set; }

    public int All { get; set; }

    public int Laboratornye { get; set; }

    public int Practika { get; set; }

    public int KursovoeProectirovanie { get; set; }

    public Enums.Component Component { get; set; }

    public UchebnyjPlanDto UchebnyjPlan { get; set; }

    public CiklovayaKomissiyaDto CiklovayaKomissiya { get; set; }
  }
}
