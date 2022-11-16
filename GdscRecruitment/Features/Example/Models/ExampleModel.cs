using GdscRecruitment.Base.Models;

namespace GdscRecruitment.Features.Example.Models;

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
