using AutoMapper;
using Common.Dtos;
using DiplomApi.PostModels;

namespace DiplomApi.Profiles
{
  public class APIProfile : Profile
  {
    public APIProfile()
    {
      CreateMap<TeacherDto, PostTeacherModel>()
         .ForMember(d => d.CiklovayaKomissiyaId, s => s.MapFrom(x => x.CiklovayaKomissiya.Id))
         .ForMember(d => d.PositionId, s => s.MapFrom(x => x.Position.Id))
         .ReverseMap();
    }
  }
}
