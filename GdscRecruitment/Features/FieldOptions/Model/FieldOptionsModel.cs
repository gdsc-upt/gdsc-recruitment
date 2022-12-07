using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Features.FieldOptions.Model;

public class FieldOptionsModel : Common.Features.Base.Model
{
    [Required]public string FieldId { get; set; }
    
    [Label("Option label")]public string Label { get; set; }
}