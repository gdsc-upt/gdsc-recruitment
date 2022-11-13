using System.ComponentModel.DataAnnotations;

namespace GdscRecruitment.Features.Forms;

public class FieldRequestView
{
    [Required] public string Name { get; set; }
    
    [Required] public bool IsRequired { get; set; }
    
    [Required] public string? Placeholder { get; set; }
}