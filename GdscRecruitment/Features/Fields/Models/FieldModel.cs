using GdscRecruitment.Common.Features.Base;

namespace GdscRecruitment.Features.Fields.Models;

public class FieldModel : Model
{
    public string Name { get; set; }

    public bool IsRequired { get; set; }

    public string? Placeholder { get; set; }
    
    public FieldTypeEnum FieldType { get; set; }
}