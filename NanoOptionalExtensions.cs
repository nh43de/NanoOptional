namespace Nh43de;

public static class NanoOptionalExtensions
{
    public static T ValueOr<T>(this NanoOptional<T> src, T defaultVal)
    {
        if (src.HasValue)
            return src.Value;

        return defaultVal;
    }
}
