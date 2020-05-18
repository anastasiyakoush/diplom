namespace Common
{
  public class Enums
  {
    public enum Component
    {
      Obscheobrazovatelnyj = 0,
      Professonalnyj = 1,
    }

    public enum Status
    {
      Faired = 0,
      Employee = 1,
      InDekret = 2
    }

    public enum Category
    {
      Superior = 0,
      First = 1,
      Second = 2
    }

    public enum PlanType
    {
      ObrazovatelnyeStardarty = 0,
      UchebnyePlany = 1,
      TipovyePlany = 2
    }

    public enum Role : byte
    {
      Admin = 0,
      User = 1
    }
  }
}
