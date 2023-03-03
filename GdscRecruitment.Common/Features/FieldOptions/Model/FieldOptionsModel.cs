using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Common.Features.FieldOptions.Model;

public class FieldOptionsModel : Base.Model
{
    [Required]public string FieldId { get; set; }
    
    [Label("Option label")]public string Label { get; set; }
}