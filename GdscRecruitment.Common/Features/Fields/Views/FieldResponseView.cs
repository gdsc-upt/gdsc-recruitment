using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Common.Features.Base;
using GdscRecruitment.Common.Features.Fields.Models;
using MudBlazor;

namespace GdscRecruitment.Common.Features.Fields.Views;

public class FieldResponseView : ViewModel
{
    [Label("Name")] [Required] public string Name { get; set; }

    [Label("IsRequired")] [Required]
    [Range(typeof(bool), "true", "false")]
    public bool IsRequired { get; set; }

    [Label("Placeholder")] public string? Placeholder { get; set; }
    
    [Label("Field Type")] [Required] public FieldTypeEnum FieldType { get; set; }

}
