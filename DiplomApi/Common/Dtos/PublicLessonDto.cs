using System;
using System.Text.RegularExpressions;

namespace Common.Dtos
{
  public class PublicLessonDto
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Topic { get; set; }
    public int MetodicheskieNarabotki { get; set; }
    public int AnalisUroka { get; set; }


    public Group Group { get; set; }
    public TeacherDto Teacher { get; set; }
    public UchebnayaDisciplinaDto UchebnayaDisciplina { get; set; }
  }
}
