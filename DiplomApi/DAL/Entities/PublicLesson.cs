using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PublicLesson
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public int MetodicheskieNarabotki { get; set; }
        public int AnalisUroka { get; set; }


        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
        public UchebnayaDisciplina UchebnayaDisciplina { get; set; }
    }
}