using System.ComponentModel.DataAnnotations;
using GdscRecruitment.Base;
using MudBlazor;

namespace GdscRecruitment.Features.Example.Models;

public class ExampleViewModel : ViewModel
{
    public ExampleViewModel(string title)
    {
        Title = title;
    }

    [Label("Title")]
    [Required]
    [StringLength(8, MinimumLength = 2, ErrorMessage = "Name length can't be less than 2 and more than 8.")]
    public string Title { get; set; }

    [Label("Type")] public ExampleTypeEnum Type { get; set; }

    [Label("Number")] public int Number { get; set; }
}
