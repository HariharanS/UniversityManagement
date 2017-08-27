using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class SubjectController
    {
		readonly ISubjectService _subjectService;
		public SubjectController(ISubjectService subjectService)
		{
			_subjectService = subjectService;
		}

		// GET api/subjects
		[HttpGet]
		public async Task<IEnumerable<SubjectModel>> Get()
		{
			var modelResult = _subjectService.GetAll();
			return modelResult.Result;
		}

		// GET api/subject/5
		[HttpGet("{id}")]
		public Task<SubjectModel> Get(int id)
		{
			return _subjectService.GetById(id);
		}

		// POST api/subject
		[HttpPost]
		public Task<SubjectModel> Post([FromBody]SubjectModel model)
		{
			var createResult = _subjectService.Create(model);
			return createResult;
		}
	    
	    // POST api/subject/3/lecture
	    [HttpPost("{id}")]
	    [Route("/lecture")]
	    public Task<LectureModel> Post(int id,[FromBody]LectureModel model)
	    {
		    var createResult = _subjectService.CreateLecture(id,model);
		    return createResult;
	    }

		// PUT api/subject/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]SubjectModel model)
		{
			throw new NotImplementedException();
		}

		// DELETE api/subject/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
    }
}
