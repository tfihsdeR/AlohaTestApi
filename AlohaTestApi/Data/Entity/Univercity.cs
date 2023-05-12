using AlohaTestApi.Core;

namespace AlohaTestApi.Data.Entity
{
    public class Univercity : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
    }
}