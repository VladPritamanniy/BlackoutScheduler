using Application.Dto;

namespace Application.Interfaces
{
    public interface IScheduleService
    {
        Task AddNewBlackoutSchedule(ScheduleDto groupDto);
    }
}
