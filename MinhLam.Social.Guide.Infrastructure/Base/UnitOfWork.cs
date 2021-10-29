using MinhLam.Social.Guide.Framework;
using MinhLam.Social.Guide.Infrastructure.Repositories;

namespace MinhLam.Social.Guide.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GuideContext dbContext;

        public UnitOfWork(GuideContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
