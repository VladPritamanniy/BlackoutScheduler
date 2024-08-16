using Core.Entities.Base;

namespace Core.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
