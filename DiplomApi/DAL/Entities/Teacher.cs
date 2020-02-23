using Common;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Enums.Category Category { get; set; }
        public Enums.Status Status { get; set; }

        [Required]
        public Position Position { get; set; }
        [Required]
        public CiklovayaKomissiya CiklovayaKomissiya { get; set; }
    }
}