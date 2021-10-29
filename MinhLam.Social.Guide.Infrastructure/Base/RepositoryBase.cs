using MinhLam.Social.Guide.Framework;
using MinhLam.Social.Guide.Infrastructure.Repositories;
using System;
using System.Data.Entity;

namespace MinhLam.Social.Guide.Infrastructure.Base
{
    public abstract class RepositoryBase<T> where T: AggregateRoot
    {
        private GuideContext context;

        public RepositoryBase(GuideContext context)
        {
            this.context = context;
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public void Add(T aggregateRoot)
        {
            context.Set<T>().Add(aggregateRoot);
        }

        public void Update(T aggregateRoot)
        {
            context.Set<T>().Attach(aggregateRoot);
            context.Entry<T>(aggregateRoot).State = EntityState.Modified;
        }
        public void Remove(T aggreateRoot)
        {
            if (context.Entry<T>(aggreateRoot).State == EntityState.Detached)
            {
                context.Set<T>().Attach(aggreateRoot);
            }

            context.Set<T>().Remove(aggreateRoot);
        }
    }
}
