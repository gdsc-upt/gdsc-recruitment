using System.ComponentModel.DataAnnotations;
using System.Reflection;
using GdscRecruitment.Common.Utilities.Attributes;
using MudBlazor;

namespace GdscRecruitment.Common.Utilities;

public static class EnumExtensions
{
    public static T? GetAttributeOfType<T>(this Enum enumValue) where T : Attribute
    {
        var type = enumValue.GetType();
        var memInfo = type.GetMember(enumValue.ToString());
        var attributes = memInfo[0].GetCustomAttributes<T>(false).ToList();
        return attributes.Count > 0 ? attributes[0] : null;
    }

    public static Color GetColor(this Enum enumValue)
    {
        return enumValue.GetAttributeOfType<DisplayColorAttribute>()?.Color ?? Color.Default;
    }

    public static string GetName(this Enum enumValue)
    {
        return enumValue.GetAttributeOfType<DisplayAttribute>()?.Name ?? enumValue.ToString();
    }

    public static string GetDescription(this Enum enumValue)
    {
        return enumValue.GetAttributeOfType<DisplayAttribute>()?.Description ?? string.Empty;
    }
}
