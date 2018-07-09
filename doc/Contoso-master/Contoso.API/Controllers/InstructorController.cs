using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Contoso.API.Infrastructure;
using Contoso.Model;
using Contoso.Service;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/Instructor")]
    public class InstructorController : ApiController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: api/Instructor
        [Route("{page:int?}")]
        public HttpResponseMessage GetAllInstructors(int? page)
        {
            var pageNumber = (page ?? 1) - 1;
            var totalCount = 0;
            var PageSize = 10;
            var students = _instructorService.GetAllInstructors(page, PageSize, out totalCount);

            var enumerable = students as IList<Instructor> ?? students.ToList();
            var response = enumerable.Any()
                ? Request.CreateResponse(HttpStatusCode.OK, enumerable)
                : Request.CreateResponse(HttpStatusCode.NotFound, "No Instructors Found");

            return response;
        }

        [HttpGet]
        [Route("{name}")]
        public IEnumerable<Instructor> GetInstructorsByNameSearch(string name)
        {
            var instructors = _instructorService.GetInstructorByName(name);
            return instructors;
        }

        // GET: api/Student/5
        [ContosoApiException]
        [Route("{id:int?}")]
        public HttpResponseMessage Get(int id)
        {
            Instructor instructor = _instructorService.GetInstructorById(id);
            if (instructor == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Instructor not found");
            return Request.CreateResponse(HttpStatusCode.OK, instructor);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create(Instructor instructor)
        {
            _instructorService.CreateInstructor(instructor);
            return Request.CreateResponse(HttpStatusCode.OK, instructor);
        }

        // POST: api/Student
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Student/5
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(Instructor instructor)
        {
            _instructorService.UpdateInstructor(instructor);
            return Request.CreateResponse(HttpStatusCode.OK, instructor);
        }

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/Student/5
        [HttpDelete]
        [Route("{id:int?}")]
        public HttpResponseMessage Delete(int id)
        {

            _instructorService.DeleteInstructorById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}