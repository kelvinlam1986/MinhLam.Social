using System.Collections.Generic;

namespace MinhLam.Social.Domain.Memberships
{
    public interface IPermissionRepository
    {
        List<Permission> GetPermissionByName(string name);
    }
}
