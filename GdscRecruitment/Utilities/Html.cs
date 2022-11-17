using System.ComponentModel.DataAnnotations;
using System.Reflection;
using GdscRecruitment.Utilities.Attributes;
using MudBlazor;

namespace GdscRecruitment.Utilities;

public static class Html
{
    public static T? GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes<T>(false).ToList();
        return attributes.Count > 0 ? attributes[0] : null;
    }

    public static Color GetDisplayColor(this Enum enumVal)
    {
        return enumVal.GetAttributeOfType<DisplayColorAttribute>()?.Color ?? Color.Default;
    }

    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetAttributeOfType<DisplayAttribute>()?.Name ?? enumValue.ToString();
    }
}
