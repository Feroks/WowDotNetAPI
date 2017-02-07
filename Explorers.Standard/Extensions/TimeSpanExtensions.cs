using System;

namespace WowDotNetAPI.Extensions
{
    public static class TimeSpanExtensions
    {
        public static DateTime UnixToDateTime(this TimeSpan unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(unixTimeStamp.TotalMilliseconds);
        }
    }
}
