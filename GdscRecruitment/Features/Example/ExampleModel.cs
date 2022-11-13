using GdscBackend.Models.Enums;
using GdscRecruitment.Base.Models;

namespace GdscRecruitment.Features.Example;

public class ExampleModel : Model
{
    public string Title { get; set; }

    public ExampleTypeEnum Type { get; set; }

    public int Number { get; set; }
}
