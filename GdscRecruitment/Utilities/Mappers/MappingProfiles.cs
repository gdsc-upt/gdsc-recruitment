using AutoMapper;
using GdscRecruitment.Features.Example.Models;
using GdscRecruitment.Features.Fields.Models;
using GdscRecruitment.Features.Fields.Views;

namespace GdscRecruitment.Utilities.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap(typeof(FieldModel), typeof(FieldResponseView)).ReverseMap();
        CreateMap<FieldModel, FieldRequestView>().ReverseMap();
        CreateMap(typeof(ExampleModel), typeof(ExampleViewModel)).ReverseMap();
    }
}
