using Application.Dto.Base;

namespace Application.Dto
{
    public class ScheduleDto : BaseDto
    {
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int GroupId { get; set; }
        public GroupDto Group { get; set; }
    }
}
