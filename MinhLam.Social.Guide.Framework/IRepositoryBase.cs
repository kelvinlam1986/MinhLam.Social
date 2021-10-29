using System;

namespace MinhLam.Social.Guide.Framework
{
    // Repository only worked wieh AggregateRoot
    public interface IRepositoryBase<T> where T: AggregateRoot
    {
        T GetById(Guid id);
        void Add(T aggregateRoot);
        void Update(T aggregateRoot);
        void Remove(T aggreateRoot);
    }
}
