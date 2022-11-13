using GdscRecruitment.Base.Models;

namespace GdscRecruitment.Features.Forms;

public class FieldModel : Model
{
    public string Name { get; set; }

    public bool IsRequiered { get; set; }

    public string Placeholder { get; set; }
}