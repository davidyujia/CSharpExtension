namespace System;
public static class DateTimeExtensions
{
    public static string ToUtcIso8061String(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.ToString("u").Replace(" ", "T");
    }

    public static string ToUtcIso8061String(this DateTime dateTime)
    {
        DateTimeOffset dateTimeOffset = dateTime;

        return dateTimeOffset.ToUtcIso8061String();
    }
}