using Application.Dto.Base;

namespace Application.Dto
{
    public class AddressDto : BaseDto
    {
        public string Street { get; set; }
        public int? GroupId { get; set; }
    }
}
