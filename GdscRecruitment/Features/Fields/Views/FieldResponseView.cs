using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Features.Fields.Views;

public class FieldResponseView
{
    [Label("Id")][Required] public string Id { get; set; }
    
    [Label("Name")][Required] public string Name { get; set; }
    
    [Label("IsRequired")][Required][Range(typeof(bool), "true", "false")]
    public bool IsRequired { get; set; }
    
    [Label("Placeholder")]public string? Placeholder { get; set; }
}