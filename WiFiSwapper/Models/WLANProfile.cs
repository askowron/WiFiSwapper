using WiFiSwapper.Code.Extensions;
using System;
using System.Xml.Serialization;

namespace WiFiSwapper.Models
{
    [XmlRoot(Namespace = "http://www.microsoft.com/networking/WLAN/profile/v1")]
    public class WLANProfile
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("SSIDConfig")]
        public SSIDConfig SSIDConfig { get; set; }

        [XmlElement("connectionType")]
        public string ConnectionType { get; set; } = "ESS";

        [XmlElement("connectionMode")]
        public string ConnectionMode { get; set; } = "auto";

        [XmlElement("MSM")]
        public MSM MSM { get; set; }

        [XmlElement("MacRandomization", Namespace = "http://www.microsoft.com/networking/WLAN/profile/v3")]
        public MacRandomization MacRandomization { get; set; }

        public WLANProfile() { }

        public WLANProfile(string name, string kind, string password)
        {
            Name = name;
            SSIDConfig = new SSIDConfig(name);
            MSM = new MSM(kind, password);
            MacRandomization = new MacRandomization();
        }
    }

    public class SSIDConfig
    {
        [XmlElement("SSID")]
        public SSID SSID { get; set; }

        public SSIDConfig() { }

        public SSIDConfig(string name)
        {
            SSID = new SSID
            {
                HEX = name.ToHEX(),
                Name = name
            };
        }
    }

    public class SSID
    {
        [XmlElement("hex")]
        public string HEX { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }

    public class MSM
    {
        [XmlElement("security")]
        public Security Security { get; set; }

        public MSM() { }

        public MSM(string kind, string password)
        {
            Security = new Security(kind, password);
        }
    }

    public class Security
    {
        [XmlElement("authEncryption")]
        public AuthEncryption AuthEncryption { get; set; }

        [XmlElement("sharedKey")]
        public SharedKey SharedKey { get; set; }

        public Security() { }

        public Security(string kind, string password)
        {
            AuthEncryption = new AuthEncryption
            {
                Authentication = kind.IN("OPEN", "WEP") ? "open" : "WPA2PSK",
                Encryption = kind.Equals("OPEN") ? "none" : kind.Equals("WEP") ? "WEP" : "AES"
            };

            SharedKey = new SharedKey
            {
                KeyType = kind.Equals("WEP") ? "networkKey" : "passPhrase",
                KeyMaterial = password
            };
        }
    }

    public class AuthEncryption
    {
        [XmlElement("authentication")]
        public string Authentication { get; set; }

        [XmlElement("encryption")]
        public string Encryption { get; set; }

        [XmlElement("useOneX")]
        public bool UseOneX { get; set; } = false;
    }

    public class SharedKey
    {
        [XmlElement("keyType")]
        public string KeyType { get; set; }

        [XmlElement("protected")]
        public bool Protected { get; set; } = false;

        [XmlElement("keyMaterial")]
        public string KeyMaterial { get; set; }
    }

    public class MacRandomization
    {
        [XmlElement("enableRandomization")]
        public bool EnableRandomization { get; set; }

        [XmlElement("randomizationSeed")]
        public long RandomizationSeed { get; set; }

        public MacRandomization()
        {
            RandomizationSeed = new Random(137137137).Next(99999999);
        }
    }
}
