using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityManagement.Application.Interfaces;
using UniversityManagement.Application.Models;

namespace UniversityManagement.API.Controllers
{
    [Route("api/[controller]")]
    public class LectureTheatreController : Controller
    {
        readonly ILectureTheatreService _lectureTheatreService;
        public LectureTheatreController(ILectureTheatreService lectureTheatreService)
        {
            _lectureTheatreService = lectureTheatreService;
        }

		// GET api/lecturetheatres
		[HttpGet]
		public async Task<IEnumerable<LectureTheatreModel>> Get()
		{
			var modelResult = _lectureTheatreService.GetAll();
			return modelResult.Result;
		}

		// GET api/lecturetheatre/5
		[HttpGet("{id}")]
		public Task<LectureTheatreModel> Get(int id)
		{
			return _lectureTheatreService.GetById(id);
		}

		// POST api/lecturetheatre
		[HttpPost]
		public Task<LectureTheatreModel> Post([FromBody]LectureTheatreModel model)
		{
			var createResult = _lectureTheatreService.Create(model);
			return createResult;
		}

		// PUT api/lecturetheatre/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]LectureTheatreModel model)
		{
			throw new NotImplementedException();
		}

		// DELETE api/lecturetheatre/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

    }
}
