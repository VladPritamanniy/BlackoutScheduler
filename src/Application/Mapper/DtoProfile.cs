using Application.Dto;
using AutoMapper;
using Core.Entities;

namespace Application.Mapper
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Schedule, ScheduleDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
