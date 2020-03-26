namespace DAL.Entities
{
  public class DocumentAuthor
  {
    public int TeacherId { get; set; }
    public int DocumentId { get; set; }
    public Teacher Teacher { get; set; }
    public Document Document { get; set; }
  }
}
