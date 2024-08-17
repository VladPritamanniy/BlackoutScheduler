using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Repositories.Base;
using Core.Specifications;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        private IMapper _mapper;
        private readonly IRepository<Group> _groupRepository;

        public GroupService(IMapper mapper, IRepository<Group> groupRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        public async Task<ScheduleDto> GetBlackoutScheduleForAddress(string addressName)
        {
            var specification = new ScheduleForAddressSpecification(addressName);
            var result = await _groupRepository.Get(specification);

            var mapped = _mapper.Map<ScheduleDto>(result);
            return mapped;
        }

        public async Task<GroupDto> GetGroupWithMaxCountBlackouts()
        {
            var specification = new GroupIdMaxCountSpecification();
            var result = await _groupRepository.FirstOrDefaultAsync(specification);

            var mapped = _mapper.Map<GroupDto>(result);
            return mapped;
        }

        public async Task<GroupDto> GetGroupWithLongestTimeBlackouts()
        {
            var procedureResult = await _groupRepository.GetTopOutageGroup();

            if (procedureResult == null)
            {
                throw new ArgumentNullException($"{nameof(procedureResult)}", "GetTopOutageGroup return null.");
            }

            var specification = new GroupItemByIdSpecification(procedureResult.GroupId);

            var result = await _groupRepository.FirstOrDefaultAsync(specification);
            var mapped = _mapper.Map<GroupDto>(result);
            return mapped;
        }

        public async Task<bool> ActualBlackoutByGroupId(int id)
        {
            var specification = new GroupItemIncludeByIdSpecification(id);
            var result = await _groupRepository.FirstOrDefaultAsync(specification);
            if (result == null)
            {
                throw new ArgumentNullException($"{nameof(result)}", $"Group not found by id {id}.");
            }

            var actualTime = DateTime.Now.TimeOfDay;
            var isActualBlackout = actualTime > result.Schedule.StartTime && actualTime < result.Schedule.FinishTime;

            return isActualBlackout;
        }

        public async Task<IEnumerable<GroupDto>> GetAllGroup()
        {
            var specification = new GroupWithIncludeSpecification();
            var result = await _groupRepository.Get(specification);
            var mapped = _mapper.Map<IEnumerable<GroupDto>>(result);
            return mapped;
        }

        public async Task<GroupDto> GetGroupById(int id)
        {
            var specification = new GroupItemIncludeByIdSpecification(id);
            var result = await _groupRepository.FirstOrDefaultAsync(specification);
            var mapped = _mapper.Map<GroupDto>(result);
            return mapped;
        }
    }
}
