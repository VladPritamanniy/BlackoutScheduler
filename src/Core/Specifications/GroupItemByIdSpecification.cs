using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class GroupItemByIdSpecification : Specification<Group>
    {
        public GroupItemByIdSpecification(int id)
        {
            AddCriteria(p => p.Id == id);
        }
    }
}
