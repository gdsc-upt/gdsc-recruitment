using GdscRecruitment.Common.Features.Base;

namespace GdscRecruitment.Common.Features.Examples.Models;

public class ExampleModel : Model
{
    public ExampleModel(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public ExampleTypeEnum Type { get; set; }

    public int Number { get; set; }
}
