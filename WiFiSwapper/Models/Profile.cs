namespace WiFiSwapper.Models
{
    public class Profile
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public ProfileKind Kind { get; set; }
    }

    public class ProfileKind
    { 
        public string Code { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
