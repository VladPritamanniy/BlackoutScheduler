using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Repositories.Base;

namespace Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private IMapper _mapper;
        private readonly IRepository<Schedule> _scheduleRepository;

        public ScheduleService(IMapper mapper, IRepository<Schedule> scheduleRepository)
        {
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public async Task AddNewBlackoutSchedule(ScheduleDto groupDto)
        {
            var mappedGroup = _mapper.Map<Schedule>(groupDto);

            _scheduleRepository.Add(mappedGroup);
            await _scheduleRepository.SaveChangesAsync();
        }
    }
}
