using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class GroupIdMaxCountSpecification : Specification<Group>
    {
        public GroupIdMaxCountSpecification()
        {
            AddCriteria(p => p.Addresses.Any());
            AddInclude(p => p.Addresses);
            ApplyOrderByDescending(p => p.Addresses.Count);
        }
    }
}
