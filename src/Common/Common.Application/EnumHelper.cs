namespace Common.Application;

public static class EnumHelper
{
    public static string ConvertToString(this Enum e)
    {
        return e.ToString().Replace("_", " ");
    }
}