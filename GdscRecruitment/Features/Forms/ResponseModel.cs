using GdscRecruitment.Base.Entities;

namespace GdscRecruitment.Features.Forms;

public class ResponseModel : Entity
{
    public string UserId { get; set; }
    
    public string FieldId { get; set; }
    
    public string Value { get; set; }
}