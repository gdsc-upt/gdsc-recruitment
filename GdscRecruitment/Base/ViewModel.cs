using MudBlazor;

namespace GdscRecruitment.Base;

public abstract class ViewModel
{
    public string Id { get; set; }

    [Label("Created")] public DateTime Created { get; set; }

    public DateTime Updated { get; set; }
}
