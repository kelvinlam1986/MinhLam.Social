using System;

namespace MinhLam.Social.Application.Profiles
{
    public class GetPrivacyFlagListByProfileReadModel
    {
        public Guid Id { get; set; }
        public Guid PrivacyFlagTypeId { get; set; }
        public Guid ProfileId { get; protected set; }
        public Guid VisibilityId { get; protected set; }
        public string VisibilityName { get; protected set; }
        public DateTime CreatedDate { get; protected set; }

    }
}

