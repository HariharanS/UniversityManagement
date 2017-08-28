using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class EnrolmentController
    {
        readonly IEnrolmentService _enrolmentService;
        public EnrolmentController(IEnrolmentService enrolmentService)
        {
            _enrolmentService = enrolmentService;
        }

        // GET api/enrolments
        [HttpGet]
        public async Task<IEnumerable<EnrolmentModel>> Get()
        {
            var modelResult = _enrolmentService.GetAll();
            return modelResult.Result;
        }

        // GET api/enrolment/5
        [HttpGet("{id}")]
        public Task<EnrolmentModel> Get(int id)
        {
            return _enrolmentService.GetById(id);
        }

        // POST api/enrolment
        [HttpPost]
        public Task<EnrolmentModel> Post([FromBody]EnrolmentModel model)
        {
            var createResult = _enrolmentService.Create(model);
            return createResult;
        }
	    
        

        // PUT api/enrolment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]EnrolmentModel model)
        {
            throw new NotImplementedException();
        }

        // DELETE api/enrolment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}