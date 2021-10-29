using MinhLam.Framework;

namespace MinhLam.Social.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialContext dbContext;

        public UnitOfWork(SocialContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

       
    }
}
