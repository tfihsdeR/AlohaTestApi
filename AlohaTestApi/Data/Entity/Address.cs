using AlohaTestApi.Core;

namespace AlohaTestApi.Data.Entity
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
