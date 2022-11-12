using GdscRecruitment.Base.Entities;

namespace GdscRecruitment.Features.Forms;

public class FieldModel : Entity
{
    public string Name { get; set; }
    
    public bool IsRequiered { get; set; }
    
    public string Placeholder { get; set; }
}