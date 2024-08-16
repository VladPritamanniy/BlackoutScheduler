using Core.Entities.Base;

namespace Core.Entities
{
    public class Schedule : BaseEntity
    {
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
