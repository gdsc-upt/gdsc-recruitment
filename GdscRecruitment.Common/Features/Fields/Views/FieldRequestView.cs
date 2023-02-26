using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Features.Fields.Models;
using MudBlazor;

namespace GdscRecruitment.Features.Fields.Views;

public class FieldRequestView
{
    [Label("Name")][Required] public string Name { get; set; }
    
    [Label("IsRequired")] [Required] public bool IsRequired { get; set; }
    
    [Label("Placeholder")] public string? Placeholder { get; set; }
    
    [Label("Field Type")] [Required] public FieldTypeEnum FieldType { get; set; }
}