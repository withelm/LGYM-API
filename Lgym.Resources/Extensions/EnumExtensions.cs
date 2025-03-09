using Lgym.Resources.Attributes;
using System.Reflection;

namespace Lgym.Resources.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var filedInfo = value.GetType().GetField(value.ToString());
            if (filedInfo == null)
            {
                return value.ToString();
            }

            var attribute = filedInfo.GetCustomAttribute<LocalizedDescriptionAttribute>(false);
            if (attribute != null)
            {
                return attribute.Description;
            }

            return value.ToString();
        }
    }
}
