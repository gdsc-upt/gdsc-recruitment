using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Features.Fields.Views;

public class FieldRequestView
{
    [Label("Name")][Required] public string Name { get; set; }
    
    [Label("IsRequired")]
    public bool IsRequired { get; set; }
    
    [Label("Placeholder")] public string? Placeholder { get; set; }
}