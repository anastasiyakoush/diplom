using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomApi.Entities
{
    public class UchebnyjPlan
    {
        public int Id { get; set; }
        public string RegistarcionnyjNomer { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public string Link { get; set; }

        public List<Group> Groups { get; set; }

        [Required]
        public virtual TipovojUchebnyjPlan TipovojUchebnyjPlan { get; set; }
    }
}