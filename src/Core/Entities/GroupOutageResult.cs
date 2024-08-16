namespace Core.Entities
{
    public class GroupOutageResult
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int TotalOutageMinutes { get; set; }
    }
}
