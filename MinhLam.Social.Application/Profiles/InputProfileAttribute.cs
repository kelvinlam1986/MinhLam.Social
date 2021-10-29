using System;

namespace MinhLam.Social.Application.Profiles
{
    public class InputProfileAttribute
    {
        public Guid Id { get; set; }
        public Guid ProfileAtributeTypeId { get; set; }
        public string Response { get; set; }
    }
}
