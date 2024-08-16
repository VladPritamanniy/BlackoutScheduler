using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public class AddressItemByIdSpecification : Specification<Address>
    {
        public AddressItemByIdSpecification(string address)
        {
            AddCriteria(p => p.Street == address);
        }
    }
}
