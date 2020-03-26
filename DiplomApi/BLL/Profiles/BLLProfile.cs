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
      CreateMap<Specialnost, SpecialnostDto>().ReverseMap();
      CreateMap<ObrazovatelnyjStandart, ObrazovatelnyjStandartDto>().ReverseMap();
      CreateMap<TipovojUchebnyjPlan, TipovojUchebnyjPlanDto>().ReverseMap();
      CreateMap<UchebnyjPlan, UchebnyjPlanDto>().ReverseMap();
      CreateMap<UchebnayaDisciplina, UchebnayaDisciplinaDto>().ReverseMap();
      CreateMap<Group, GroupDto>().ReverseMap();
      CreateMap<PublicLesson, PublicLessonDto>().ReverseMap();
      CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
      CreateMap<Document, DocumentDto>()
        .ForMember(d => d.Authors, s => s.MapFrom(x => x.DocumentAuthors))
        .ReverseMap();
      CreateMap<TeacherDto, DocumentAuthor>()
        .ForMember(d => d.Teacher, s => s.MapFrom(x => x))
        .ForMember(d => d.TeacherId, s => s.MapFrom(x => x.Id))
        .ReverseMap();

    }
  }
}
