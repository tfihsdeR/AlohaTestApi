using AlohaTestApi.Data.DTO;
using AlohaTestApi.Data.Entity;
using AlohaTestApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AlohaTestApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AddressController : Controller
    {
        MyDbContext context;

        public AddressController()
        {
            context = new MyDbContext();
        }

        [HttpGet]
        public List<Address> GetAll()
        {
            return context.Addresses.ToList();
        }

        [HttpGet("{id}")]
        public Address GetById(int id)
        {
            return context.Addresses.Find(id);
        }

        [HttpPost]
        public Address Add(AddressDto address)
        {
            Address _address = new Address();
            _address.Street = address.Street;
            _address.Description = address.Description;
            _address.Name = address.Name;
            _address.CityId = context.Cities.FirstOrDefault(c => c.Name == address.City).Id;

            context.Addresses.Add(_address);
            context.SaveChanges();

            return _address;
        }

        [HttpDelete]
        public string DeleteById(int id)
        {
            context.Remove(context.Addresses.Find(id));
            return "Deleted Succeed";
        }
    }
}
