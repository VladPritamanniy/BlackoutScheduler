using Application.Dto;

namespace Application.Interfaces
{
    public interface IAddressSevice
    {
        Task<IEnumerable<AddressDto>> GetNotAssignedAddresses();
        Task AssignGroupToAddress(string addressName, int groupId);
        Task AddTwoNewAddresses(List<AddressDto> addressDtoList);
    }
}
