using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Common.Utilities.Attributes;
using Color = MudBlazor.Color;

namespace GdscRecruitment.Common.Features.Fields.Models;

public enum FieldTypeEnum
{
    [DisplayColor(Color.Primary)] [Display(Name = "Text Field")]
    Text,
    
    [DisplayColor(Color.Secondary)] [Display(Name = "Dropdown Field")]
    Dropdown,
    
    [DisplayColor(Color.Tertiary)] [Display(Name = "Radio Buttons Field")]
    Radio,
    
    [DisplayColor(Color.Info)] [Display(Name = "Checkbox Field")]
    Checkbox
}