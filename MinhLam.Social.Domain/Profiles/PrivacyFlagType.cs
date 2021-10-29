using MinhLam.Framework;

namespace MinhLam.Social.Domain.Profiles
{
    public class PrivacyFlagType : Entity
    {
        public static string IM = "IM";
        public static string AccountInfo = "Account Info";
        public static string TankInfo = "Tank Info";
        public string FieldName { get; protected set; }
        public int SortOrder { get; protected set; }
    }
}
