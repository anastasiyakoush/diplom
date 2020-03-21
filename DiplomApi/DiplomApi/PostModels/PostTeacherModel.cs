using Common;

namespace DiplomApi.PostModels
{
  public class PostTeacherModel
  {
    public int? Id { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string FatherName { get; set; }

    public Enums.Category Category { get; set; }

    public Enums.Status Status { get; set; }

    public int? PositionId { get; set; }

    public int? CiklovayaKomissiyaId { get; set; }
  }
}
