using MinhLam.Social.Guide.Domain.Models;
using System.Data.Entity;

namespace MinhLam.Social.Guide.Infrastructure.Repositories
{
    public class GuideContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
