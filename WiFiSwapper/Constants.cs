namespace WiFiSwapper
{
    internal class Constants
    {
        public static string PROFILES = "Profiles\\";
        public static string BACKUP = "Backup\\";
        public static string LOCK = "Lock\\";

        public static string REGISTRY_PATH_ROOT =       "SOFTWARE\\Appit\\WiFiSwapper\\";
        public static string REGISTRY_PATH_PROFILES =   $"SOFTWARE\\Appit\\WiFiSwapper\\{PROFILES}";
        public static string REGISTRY_PATH_LOCK =       $"SOFTWARE\\Appit\\WiFiSwapper\\{LOCK}";
    }
}
