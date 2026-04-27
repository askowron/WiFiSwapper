using System;
using System.Linq;
using System.Text;

namespace WiFiSwapper.Code.Extensions
{
    public static class StringExt
    {
        public static string ToHEX(this string str)
        {
            return BitConverter.ToString(Encoding.ASCII.GetBytes(str)).Replace("-", "");
        }

        public static byte[] Base64(this string text)
        {
            return Encoding.ASCII.GetBytes(Convert.ToBase64String(Encoding.UTF8.GetBytes(text)));
        }

        public static string Base64(this byte[] data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.ASCII.GetString(data)));
        }

        public static byte[] ToByteArray(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static bool IN(this string text, params string[] items)
        {
            return items.Contains(text);
        }
    }
}
