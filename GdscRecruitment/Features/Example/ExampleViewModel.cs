using System.ComponentModel.DataAnnotations;
using GdscBackend.Models.Enums;
using MudBlazor;

namespace GdscRecruitment.Features.Example;

public class ExampleViewModel
{
    [Label("Title")]
    [Required]
    [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
    public string Title { get; set; }

    [Label("Type")] public ExampleTypeEnum Type { get; set; }

    [Label("Number")] public int Number { get; set; }
}
