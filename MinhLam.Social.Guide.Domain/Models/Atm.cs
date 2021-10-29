using MinhLam.Social.Guide.Domain.DomainEvents;
using MinhLam.Social.Guide.Framework;

namespace MinhLam.Social.Guide.Domain.Models
{
    public class Atm : AggregateRoot
    {
        public decimal Balance { get; private set; }

        public void TakeMoney(decimal money)
        {
            Balance = Balance - money;
            AddDomainEvents(new BalanceChangedEvent(Balance));
        }
    }
}
