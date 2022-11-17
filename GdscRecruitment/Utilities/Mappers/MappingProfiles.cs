using AutoMapper;
using GdscRecruitment.Features.Example.Models;
using GdscRecruitment.Features.Forms;

namespace GdscRecruitment.Utilities.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap(typeof(FieldModel), typeof(FieldResponseView)).ReverseMap();
        CreateMap(typeof(ExampleModel), typeof(ExampleViewModel)).ReverseMap();
    }
}
