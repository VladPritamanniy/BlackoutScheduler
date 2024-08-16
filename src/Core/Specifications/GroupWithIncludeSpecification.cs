using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class GroupWithIncludeSpecification : Specification<Group>
    {
        public GroupWithIncludeSpecification()
        {
            AddInclude(p => p.Addresses);
            AddInclude(p => p.Schedule);
        }
    }
}
