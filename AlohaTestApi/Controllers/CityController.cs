using AlohaTestApi.Data.DTO;
using AlohaTestApi.Data.Entity;
using AlohaTestApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AlohaTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        MyDbContext context;

        public CityController()
        {
            context = new MyDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Cities.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(context.Cities.Find(id));
        }

        [HttpPost]
        public IActionResult Create(CityDto city)
        {
            City _city = new City()
            {
                Name = city.Name,
                CountryId = context.Countries.FirstOrDefault(c => c.Name == city.CountryName).Id
            };
            context.Cities.Add(_city);
            return Ok(context.SaveChanges());
        }

        [HttpPut("{id}")]
        public IActionResult Update(CityDto city, int id)
        {
            City _city = context.Cities.Find(id);
            _city.Name = city.Name;
            _city.CountryId = context.Countries.FirstOrDefault(c => c.Name == city.CountryName).Id;
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            context.Cities.Remove(context.Cities.Find(id));
            return Ok(context.SaveChanges());
        }
    }
}
