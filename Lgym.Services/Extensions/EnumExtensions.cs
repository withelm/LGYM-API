namespace Lgym.Services.Extensions
{
    public static class EnumExtensions
    {
        public static T ParseEnum<T>(this string value) where T : struct
        {
            return Enum.Parse<T>(value);
        }
    }
}
