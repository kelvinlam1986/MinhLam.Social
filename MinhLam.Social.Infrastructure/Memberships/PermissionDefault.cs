using MinhLam.Social.Domain.Memberships;
using System;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class PermissionDefault : IPermissionDefault
    {
        private IPermissionRepository permissionRepository;

        public PermissionDefault(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        public Permission GetPermissionForNewAccount()
        {
            var publicPermissions = this.permissionRepository.GetPermissionByName("PUBLIC");
            return publicPermissions.FirstOrDefault();
        }
    }
}
