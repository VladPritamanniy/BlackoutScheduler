using Core.Entities.Base;

namespace Core.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public HashSet<Address> Addresses { get; set; }
        public Schedule Schedule { get; set; }
    }
}
