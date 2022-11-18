using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using GdscRecruitment.Utilities.Attributes;
using MudBlazor;

namespace GdscRecruitment.Utilities;

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

public class Html<T>
{
    public string GetLabel(Expression<Func<T, object>> property)
    {
        var member = GetMemberExpression(property);
        if (member is null)
        {
            return string.Empty;
        }

        var display = member.Member.GetCustomAttribute<LabelAttribute>();
        return display?.Name ?? member.Member.Name;
    }

    private static MemberExpression? GetMemberExpression(Expression<Func<T, object>> expr)
    {
        switch (expr.Body.NodeType)
        {
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                var ue = expr.Body as UnaryExpression;
                return ue?.Operand as MemberExpression;
            default:
                return expr.Body as MemberExpression;
        }
    }
}
