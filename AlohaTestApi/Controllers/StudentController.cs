using AlohaTestApi.Data.DTO;
using AlohaTestApi.Data.Entity;
using AlohaTestApi.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlohaTestApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentController : Controller
    {
        MyDbContext context;
        public StudentController()
        {
            context = new MyDbContext();
        }

        [HttpGet]
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
            return context.Students.Find(id);
        }

        [HttpPost]
        public Student Add(StudentDto student)
        {
            Student _student = new Student();
            
            _student.AddressId = context.Addresses.FirstOrDefault(a => a.Name == student.Address).Id;
            _student.Name = student.Name;
            _student.Email = student.Email;
            _student.Phone = student.Phone;
            _student.Surname = student.Surname;

            context.Students.Add( _student );
            context.SaveChanges();

            return _student;
        }


        [HttpDelete]
        public string DeleteById(int id)
        {
            context.Remove(context.Students.Find(id));
            return "Deleted Succeed";
        }
    }
}
