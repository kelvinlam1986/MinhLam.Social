using MinhLam.Social.Domain.Memberships;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class TermRepository : RepositoryBase<Term>, ITermRepository
    {
        public TermRepository(SocialContext dbContext) : base(dbContext)
        {
        }
    }
}
