using System;

namespace MinhLam.Social.Application.Profiles
{
    public class SetUseGravatarCommand
    {
        public SetUseGravatarCommand(Guid profileId)
        {
            ProfileId = profileId;
        }

        public Guid ProfileId { get; set; }
    }
}
