using MinhLam.Social.Domain.Memberships;
using System;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class TermCheckExisting : ITermCheckExisting
    {
        private ITermRepository termRepository;

        public TermCheckExisting(ITermRepository termRepository)
        {
            this.termRepository = termRepository;
        }

        public bool Execute(Guid id)
        {
            var term = this.termRepository.GetById(id);
            return term != null;
        }
    }
}
