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
      CreateMap<ObrazovatelnyjStandartDto, PostPlanModel>()
         .ForMember(d => d.DependencyId, s => s.MapFrom(x => x.Specialnost.Id))
         .ReverseMap();
      CreateMap<TipovojUchebnyjPlanDto, PostPlanModel>()
         .ForMember(d => d.DependencyId, s => s.MapFrom(x => x.ObrazovatelnyjStandart.Id))
         .ReverseMap();
      CreateMap<UchebnyjPlanDto, PostPlanModel>()
         .ForMember(d => d.DependencyId, s => s.MapFrom(x => x.TipovojUchebnyjPlan.Id))
         .ReverseMap();
    }
  }
}
