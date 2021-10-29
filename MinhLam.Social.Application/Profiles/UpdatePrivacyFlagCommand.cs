using System;

namespace MinhLam.Social.Application.Profiles
{
    public class UpdatePrivacyFlagCommand
    {
        public UpdatePrivacyFlagCommand(
            Guid id,
            Guid privacyFlagTypeId,
            Guid profileId,
            Guid visibilityId)
        {
            this.Id = id;
            this.PrivacyFlagTypeId = privacyFlagTypeId;
            this.ProfileId = profileId;
            this.VisibilityId = visibilityId;
        }

        public Guid Id { get; set; }
        public Guid PrivacyFlagTypeId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid VisibilityId { get; set; }
    }
}
