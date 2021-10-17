using System;
using System.ComponentModel;

namespace BotOMat
{
    //         Reflection to return enum descriptions:
    public static class RobotExtensions
    {
        public static string GetDescription<T>(this T enumValue) where T : struct, Enum
        {
            var enumInfo = typeof(T).GetField(enumValue.ToString());
            if (enumInfo != null)
            {
                var attributes = enumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute[])attributes)[0].Description;
                }
            }
            //otherwise
            return enumValue.ToString();
        }
    }
}
