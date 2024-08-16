using Application.Dto.Base;

namespace Application.Dto
{
    public class GroupDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public HashSet<AddressDto> Addresses { get; set; }
        public ScheduleDto Schedule { get; set; }
    }
}
