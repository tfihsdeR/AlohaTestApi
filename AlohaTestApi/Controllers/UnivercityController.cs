using AlohaTestApi.Data.DTO;
using AlohaTestApi.Data.Entity;
using AlohaTestApi.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlohaTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnivercityController : ControllerBase
    {
        MyDbContext context;

        public UnivercityController()
        {
            context = new MyDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Univercities.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(context.Univercities.Find(id));
        }

        [HttpPost]
        public IActionResult Create(UnivercityDto univercity)
        {
            Univercity _univercity = new Univercity()
            {
                Name = univercity.Name,
                CityId = context.Cities.FirstOrDefault(c => c.Name == univercity.City).Id
            };
            context.Univercities.Add(_univercity);
            return Ok(context.SaveChanges());
        }

        [HttpPut("{id}")]
        public IActionResult Update(UnivercityDto univercity, int id)
        {
            Univercity _univercity = context.Univercities.Find(id);
            _univercity.Name = univercity.Name;
            _univercity.CityId = context.Cities.FirstOrDefault(c => c.Name == univercity.City).Id;
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{i}")]
        public IActionResult DeleteById(int id)
        {
            context.Univercities.Remove(context.Univercities.Find(id));
            return Ok(context.SaveChanges());
        }
    }
}
