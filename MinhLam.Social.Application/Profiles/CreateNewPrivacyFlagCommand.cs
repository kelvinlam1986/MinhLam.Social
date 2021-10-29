using System;

namespace MinhLam.Social.Application.Profiles
{
    public class CreateNewPrivacyFlagCommand
    {
        public CreateNewPrivacyFlagCommand(
            Guid privacyFlagTypeId,
            Guid profileId,
            Guid visibilityId)
        {
            this.PrivacyFlagTypeId = privacyFlagTypeId;
            this.ProfileId = profileId;
            this.VisibilityId = visibilityId;
        }

        public Guid PrivacyFlagTypeId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid VisibilityId { get; set; }
    }
}
