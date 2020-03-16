using AutoMapper;
using Common.Dtos;
using DAL.Entities;

namespace BLL.Profiles
{
  public class BLLProfile : Profile
  {
    public BLLProfile()
    {
      CreateMap<Teacher, TeacherDto>().ReverseMap();
      CreateMap<Position, PositionDto>().ReverseMap();
      CreateMap<CiklovayaKomissiya, CiklovayaKomissiyaDto>().ReverseMap();
    }
  }
}
