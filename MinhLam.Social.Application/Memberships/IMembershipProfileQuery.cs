using System;

namespace MinhLam.Social.Application.Memberships
{
    public interface IMembershipProfileQuery
    {
        GetMembershipCurrentProfileReadModel GetCurrentProfile(Guid accountId);
    }
}
