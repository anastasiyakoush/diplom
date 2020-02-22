using System.ComponentModel.DataAnnotations;

namespace DiplomApi.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public virtual UchebnyjPlan UchebnyjPlan { get; set; }
        [Required]
        public virtual Specialnost Specialnost { get; set; }
    }
}