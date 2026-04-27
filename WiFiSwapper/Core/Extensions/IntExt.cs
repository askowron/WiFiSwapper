using System;

namespace WiFiSwapper.Core.Extensions
{
    public static class IntExt
    {
        public static int NotLessThan(this int value, int minValue)
        {
            return Math.Max(value, minValue);
        }
    }
}
