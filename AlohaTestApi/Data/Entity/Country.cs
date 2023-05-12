using AlohaTestApi.Core;

namespace AlohaTestApi.Data.Entity
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public City City { get; set; }
    }
}