using System.Text;

namespace WiFiSwapper.Core.Extensions
{
    public static class ByteArrayExt
    {
        public static string AsString(this byte[] bytes)
        { 
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
