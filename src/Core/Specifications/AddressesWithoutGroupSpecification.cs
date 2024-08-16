using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public sealed class AddressesWithoutGroupSpecification : Specification<Address>
    {
        public AddressesWithoutGroupSpecification()
        {
            AddCriteria(p => p.GroupId == null);
        }
    }
}
