using System;

namespace WiFiSwapper.Core.Extensions
{
    public static class DecimalExt
    {
        public static int ToInt(this decimal value)
        {
            return (int)Math.Floor(value);
        }
    }
}
