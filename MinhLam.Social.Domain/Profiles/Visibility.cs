using MinhLam.Framework;

namespace MinhLam.Social.Domain.Profiles
{
    public class Visibility : Entity
    {
        public static string Private = "Private";
        public static string Friend = "Friend";
        public static string Public = "Public";

        public string Name { get; set; }
    }
}
