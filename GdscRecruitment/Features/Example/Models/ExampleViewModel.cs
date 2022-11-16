using System.ComponentModel.DataAnnotations;
using MudBlazor;

namespace GdscRecruitment.Features.Example.Models;

public class ExampleViewModel
{
    public ExampleViewModel(string title)
    {
        Title = title;
    }

    [Label("Title")]
    [Required]
    [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
    public string Title { get; set; }

    [Label("Type")] public ExampleTypeEnum Type { get; set; }

    [Label("Number")] public int Number { get; set; }
}
