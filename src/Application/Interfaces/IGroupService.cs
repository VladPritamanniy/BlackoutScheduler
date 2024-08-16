using Application.Dto;

namespace Application.Interfaces
{
    public interface IGroupService
    {
        Task<ScheduleDto> GetBlackoutScheduleForAddress(string addressName);
        Task<GroupDto> GetGroupWithMaxCountBlackouts();
        Task<GroupDto> GetGroupWithLongestTimeBlackouts();
        Task<bool> ActualBlackoutByGroupId(int id);
        Task<IEnumerable<GroupDto>> GetAllGroup();
        Task<GroupDto> GetGroupById(int id);
    }
}
