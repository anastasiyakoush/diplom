using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomApi.Entities
{
    public class TipovojUchebnyjPlan
    {
        public int Id { get; set; }
        public string RegistarcionnyjNomer { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string Link { get; set; }

        [Required]
        public virtual ObrazovatelnyjStandart ObrazovatelnyjStandart { get; set; }
    }
}