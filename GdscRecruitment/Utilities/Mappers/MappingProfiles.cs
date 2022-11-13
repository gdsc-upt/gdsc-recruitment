using AutoMapper;
using GdscRecruitment.Features.Forms;

namespace GdscRecruitment.Utilities.Mappers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap(typeof(FieldModel), typeof(FieldResponseView));
        // CreateMap(typeof(ResponseModel), typeof());
        
    }
}