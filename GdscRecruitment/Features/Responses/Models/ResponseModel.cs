using GdscRecruitment.Common.Features.Base;

namespace GdscRecruitment.Features.Responses.Models;

public class ResponseModel : Model
{
    public string UserId { get; set; }

    public string FieldId { get; set; }

    public string Value { get; set; }
}