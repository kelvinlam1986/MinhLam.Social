using MinhLam.Framework;
using System;

namespace MinhLam.Social.Domain.Memberships
{
    public class Term : AggregateRoot
    {
        protected Term()
        {
        }

        public string Terms { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
    }
}
