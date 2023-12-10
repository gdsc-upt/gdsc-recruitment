using AutoMapper;
using GdscRecruitment.Common.Features.Examples.Models;
using GdscRecruitment.Common.Features.Fields.Models;
using GdscRecruitment.Common.Features.Fields.Views;
using GdscRecruitment.Common.Features.Responses.Models;
using GdscRecruitment.Common.Features.Responses.Views;
using GdscRecruitment.Common.Features.Teams.Models;
using GdscRecruitment.Common.Features.Teams.Views;
using GdscRecruitment.Common.Features.Workshops.Models;
using GdscRecruitment.Common.Features.Workshops.Views;

namespace GdscRecruitment.Common.Utilities.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap(typeof(FieldModel), typeof(FieldResponseView)).ReverseMap();
        CreateMap<FieldModel, FieldRequestView>().ReverseMap();
        CreateMap<ResponseModel, ResponseRequestView>().ReverseMap();
        CreateMap<ResponseModel, ResponseResponseView>().ReverseMap();
        CreateMap<TeamModel, TeamResponse>().ReverseMap();
        CreateMap<TeamModel, TeamRequest>().ReverseMap();
        CreateMap(typeof(ExampleModel), typeof(ExampleViewModel)).ReverseMap();
        CreateMap<WorkshopModel, WorkshopRequest>().ReverseMap();
    }
}
