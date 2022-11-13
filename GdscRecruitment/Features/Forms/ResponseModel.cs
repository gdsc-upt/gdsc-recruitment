using GdscRecruitment.Base.Models;

namespace GdscRecruitment.Features.Forms;

public class ResponseModel : Model
{
    public string UserId { get; set; }

    public string FieldId { get; set; }

    public string Value { get; set; }
}