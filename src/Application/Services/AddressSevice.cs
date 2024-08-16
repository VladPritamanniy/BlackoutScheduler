using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Repositories.Base;
using Core.Specifications;

namespace Application.Services
{
    public class AddressSevice : IAddressSevice
    {
        private IMapper _mapper;
        private readonly IRepository<Address> _addressRepository;

        public AddressSevice(IMapper mapper, IRepository<Address> addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<AddressDto>> GetNotAssignedAddresses()
        {
            var specification = new AddressesWithoutGroupSpecification();
            var result = await _addressRepository.Get(specification);

            var mapped = _mapper.Map<IEnumerable<AddressDto>>(result);
            return mapped;
        }

        public async Task AssignGroupToAddress(string addressName, int groupId)
        {
            var specification = new AddressItemByIdSpecification(addressName);

            var entity = await _addressRepository.FirstOrDefaultAsync(specification);

            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(entity)}", $"Cannon get address by name = {addressName}.");
            }
            entity.GroupId = groupId;

            await _addressRepository.SaveChangesAsync();
        }

        public async Task AddTwoNewAddresses(List<AddressDto> addressDtoList)
        {
            var mapped = _mapper.Map<IEnumerable<Address>>(addressDtoList);

            foreach (var item in mapped)
            {
                _addressRepository.Add(item);
            }

            await _addressRepository.SaveChangesAsync();
        }
    }
}
