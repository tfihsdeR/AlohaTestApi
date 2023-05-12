using AlohaTestApi.Core;

namespace AlohaTestApi.Data.Entity
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int AddressId { get; set; }
        public Address Adress { get; set; }
    }
}
