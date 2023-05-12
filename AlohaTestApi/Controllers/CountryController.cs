using AlohaTestApi.Data.DTO;
using AlohaTestApi.Data.Entity;
using AlohaTestApi.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlohaTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        MyDbContext context;

        public CountryController()
        {
            context = new MyDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Countries.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(context.Countries.Find(id));
        }

        [HttpPost]
        public IActionResult Create(CountryDto country)
        {
            Country _country = new Country
            {
                Name = country.Name
            };
            context.Countries.Add(_country);
            return Ok(context.SaveChanges());
        }

        [HttpPut("{id}")]
        public IActionResult Update(CountryDto country, int id)
        {
            Country _country = context.Countries.Find(id);
            _country.Name = country.Name;
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            context.Countries.Remove(context.Countries.Find(id));
            return Ok(context.SaveChanges());
        }
    }
}
