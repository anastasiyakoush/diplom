using System;
using System.Text.RegularExpressions;

namespace Common.Dtos
{
  public class PublicLessonDto
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Topic { get; set; }
    public string MetodicheskieNarabotki { get; set; }
    public string AnalisUroka { get; set; }


    public GroupDto Group { get; set; }
    public TeacherDto Teacher { get; set; }
    public UchebnayaDisciplinaDto UchebnayaDisciplina { get; set; }
  }
}
