using MinhLam.Social.Guide.Framework;
using System;

namespace MinhLam.Social.Guide.Domain.DomainEvents
{
    public class BalanceChangeEventHandler : IHandler<BalanceChangedEvent>
    {
        public void Handle(BalanceChangedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
