using System;

namespace MinhLam.Social.Domain.Memberships
{
    public interface ITermCheckExisting
    {
        bool Execute(Guid id);
    }
}
