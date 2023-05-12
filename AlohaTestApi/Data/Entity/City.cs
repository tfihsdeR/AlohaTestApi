using AlohaTestApi.Core;

namespace AlohaTestApi.Data.Entity
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public Address Address { get; set; }
        public Univercity Univercity { get; set; }
    }
}
