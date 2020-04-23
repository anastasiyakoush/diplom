using Common;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
  public class UchebnayaDisciplina
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int All { get; set; }
    public int Laboratornye { get; set; }
    public int Practika { get; set; }
    public int KursovoeProectirovanie { get; set; }
    public Enums.Component Component { get; set; }


    public virtual UchebnyjPlan UchebnyjPlan { get; set; }
    public virtual CiklovayaKomissiya CiklovayaKomissiya { get; set; }
  }
}
