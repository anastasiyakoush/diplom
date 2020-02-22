using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class UchebnayaDisciplina
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegistarcionnyjNomer { get; set; }
        public int Laboratornye { get; set; }
        public int Practika { get; set; }
        public int KursovoeProectirovanie { get; set; }
        public Enums.Component Component { get; set; }


        [Required]
        public virtual UchebnyjPlan UchebnyjPlan { get; set; }
        [Required]
        public virtual CiklovayaKomissiya CiklovayaKomissiya { get; set; }
    }
}