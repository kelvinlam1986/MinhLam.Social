using MinhLam.Social.Domain.Memberships;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(SocialContext dbContext) : base(dbContext)
        {
        }

        public List<Permission> GetPermissionByName(string name)
        {
            return this.DbContext.Permissions.Where(x => x.Name == name).ToList();
        }
    }
}
