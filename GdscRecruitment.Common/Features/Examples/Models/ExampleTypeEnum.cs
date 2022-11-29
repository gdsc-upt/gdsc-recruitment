using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Common.Utilities.Attributes;
using MudBlazor;

namespace GdscRecruitment.Common.Features.Examples.Models;

public enum ExampleTypeEnum
{
    [DisplayColor(Color.Info)] [Display(Name = "Easy")]
    EasyExample,

    [DisplayColor(Color.Warning)] [Display(Name = "Hard", Description = "It's harder than it looks")]
    NotEasyExample,

    [DisplayColor(Color.Error)] [Display(Name = "WTF")]
    WtfExample
}
