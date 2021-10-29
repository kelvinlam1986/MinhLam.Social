using MinhLam.Social.Guide.Framework;

namespace MinhLam.Social.Guide.Domain.DomainEvents
{
    public class BalanceChangedEvent : IDomainEvent
    {
        public decimal Delta { get; private set; }
        public BalanceChangedEvent(decimal delta)
        {
            Delta = delta;
        }
    }
}
