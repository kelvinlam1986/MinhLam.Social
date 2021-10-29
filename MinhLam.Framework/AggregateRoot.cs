using System.Collections.Generic;

namespace MinhLam.Framework
{
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyList<IDomainEvent> DomainEvents
        {
            get { return domainEvents; }
        }

        protected void AddDomainEvents(IDomainEvent newEvent)
        {
            domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            domainEvents.Clear();
        }
    }
}
