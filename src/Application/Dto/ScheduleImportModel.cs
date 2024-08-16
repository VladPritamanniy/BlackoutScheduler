namespace Application.Dto
{
    public class ScheduleImportModel
    {
        public int GroupId { get; set; }
        public List<TimeModel> Times { get; set; } = new List<TimeModel>();
    }
}
