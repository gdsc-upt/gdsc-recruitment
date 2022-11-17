using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Utilities.Attributes;
using MudBlazor;

namespace GdscRecruitment.Features.Example.Models;

public enum ExampleTypeEnum
{
    [DisplayColor(Color.Info)] [Display(Name = "Easy")]
    EasyExample,

    [DisplayColor(Color.Warning)] [Display(Name = "Hard")]
    NotEasyExample,

    [DisplayColor(Color.Error)] [Display(Name = "WTF")]
    WtfExample
}
