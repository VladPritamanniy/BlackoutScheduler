using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class GroupItemIncludeByIdSpecification : Specification<Group>
    {
        public GroupItemIncludeByIdSpecification(int id)
        {
            AddCriteria(p => p.Id == id);
            AddInclude(p => p.Addresses);
            AddInclude(p => p.Schedule);
        }
    }
}
