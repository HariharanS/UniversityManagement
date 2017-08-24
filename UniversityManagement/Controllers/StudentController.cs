using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        readonly IStudentService _studentService;

        public StudentController(IStudentService studentService) => _studentService = studentService;

        // GET api/values
        [HttpGet]
        public Task<IEnumerable<StudentModel>> Get()
        {
            //return new string[] { "value1", "value2" };
            return _studentService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Task<StudentModel> Get(int id)
        {
            return _studentService.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]StudentModel model)
        {
            _studentService.Create(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StudentModel model)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
