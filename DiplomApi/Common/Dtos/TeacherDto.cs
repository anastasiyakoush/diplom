namespace Common.Dtos
{
    public class TeacherDto
    {
        public int? Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Enums.Category Category { get; set; }
        public Enums.Status Status { get; set; }
        public PositionDto Position { get; set; }
        public CiklovayaKomissiyaDto CiklovayaKomissiya { get; set; }
    }
}
