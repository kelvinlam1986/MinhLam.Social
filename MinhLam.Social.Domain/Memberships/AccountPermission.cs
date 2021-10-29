using MinhLam.Framework;
using System;

namespace MinhLam.Social.Domain.Memberships
{
    public class AccountPermission : Entity
    {
        public Guid AccountId { get; protected set; }
        public Guid PermissionId { get; protected set; }

        internal AccountPermission(Guid accountId, Guid permissionId)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            PermissionId = permissionId;
        }
    }
}
