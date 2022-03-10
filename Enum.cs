using System.ComponentModel;

namespace System;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var enumString = value.ToString();

        var enumType = value.GetType();

        var memberInfos = enumType.GetMember(value.ToString());

        var enumValueMemberInfo = memberInfos.FirstOrDefault(x => x.DeclaringType == enumType);

        if (enumValueMemberInfo == null ||
            enumValueMemberInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() is not DescriptionAttribute valueAttribute)
        {
            return enumString;
        }

        var description = valueAttribute.Description;

        return description;
    }
}