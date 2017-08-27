using System;
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

        // GET api/students
        [HttpGet]
        public async Task<IEnumerable<StudentModel>> Get()
        {
            var modelResult = _studentService.GetAll();
            return modelResult.Result;
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public Task<StudentModel> Get(int id)
        {
            return _studentService.GetById(id);
        }

        // POST api/students
        [HttpPost]
        public Task<StudentModel> Post([FromBody]StudentModel model)
        {
            var createResult = _studentService.Create(model);
            return createResult;
        }
        // POST api/student/3/lecture/2
        [HttpPost("{id}/")]
        [Route("/lecture/{lectureId}")]
        public Task<EnrolmentModel> Post(int id,int lectureId)
        {
            var createResult = _studentService.Enrol(id, lectureId);
            return createResult;
        }

        // PUT api/students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StudentModel model)
        {
            throw new NotImplementedException();
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
