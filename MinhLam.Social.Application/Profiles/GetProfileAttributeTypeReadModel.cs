using System;

namespace MinhLam.Social.Application.Profiles
{
    public class GetProfileAttributeTypeReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
