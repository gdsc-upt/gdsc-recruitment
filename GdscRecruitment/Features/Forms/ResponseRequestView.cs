using System.ComponentModel.DataAnnotations;

namespace GdscRecruitment.Features.Forms;

public class ResponseRequestView
{
    [Required] public string UserId { get; set; }
    
    [Required] public string FieldId { get; set; }
    
    [Required] public string Value { get; set; }
}