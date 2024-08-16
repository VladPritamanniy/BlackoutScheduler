using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications
{
    public sealed class ScheduleForAddressSpecification : Specification<Group, Schedule>
    {
        public ScheduleForAddressSpecification(string address)
        {
            AddCriteria(p => p.Addresses.Any(a => a.Street.Contains(address)));

            AddInclude(p => p.Addresses);
            AddInclude(p => p.Schedule);

            ApplySelector(p => new Schedule
            {
                Id = p.Schedule.Id,
                DayOfWeek = p.Schedule.DayOfWeek,
                StartTime = p.Schedule.StartTime,
                FinishTime = p.Schedule.FinishTime,
                GroupId = p.Schedule.GroupId,
                Group = p
            });
        }
    }
}
