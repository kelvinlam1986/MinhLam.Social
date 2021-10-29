using MinhLam.Framework;

namespace MinhLam.Social.Domain.Profiles
{
    public class LevelOfExperience : Entity
    {
        public string Name { get; protected set; }
        public int SortOrder { get; protected set; }

        protected LevelOfExperience()
        {
        }
    }
}
