using MinhLam.Framework;
using System;
using System.Collections.Generic;

namespace MinhLam.Social.Domain.Memberships
{
    public class Permission : AggregateRoot
    {
        public Permission(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Permission()
        {
        }

        public string Name { get; protected set; }
        public virtual ICollection<Account> Accounts { get; protected set; }
    }
}
