using static Common.Enums;

namespace DiplomApi.PostModels
{
  public class PostUserModel
  {
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public Role Role { get; set; }
  }
}
