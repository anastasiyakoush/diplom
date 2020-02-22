namespace DiplomApi.Entities
{
    public class DocumentAuthor
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public Document Document { get; set; }
    }
}