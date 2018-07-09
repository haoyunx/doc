using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Contoso.API.Infrastructure;
using Contoso.Model;
using Contoso.Service;

namespace Contoso.API.Controllers
{
    [RoutePrefix("api/Department")]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Department
        [Route("")]
        public HttpResponseMessage GetAllDepartments()
        {
            var departments = _departmentService.GetAllDepartments();

            var enumerable = departments as IList<Department> ?? departments.ToList();
            var response = enumerable.Any()
                ? Request.CreateResponse(HttpStatusCode.OK, enumerable)
                : Request.CreateResponse(HttpStatusCode.NotFound, "No Departments Found");

            return response;
        }

        [Route("{name}")]
        public HttpResponseMessage GetDepartmentsByNameSearch(string name)
        {
            var departments = _departmentService.GetDepartmentByName(name);

            if (departments == null || departments.Count() == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No departments found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        // GET: api/Department/5
        [ContosoApiException]
        [Route("{id:int?}")]
        public HttpResponseMessage Get(int id)
        {
            Department department = _departmentService.GetDepartmentById(id);
            if (department == null) return Request.CreateResponse(HttpStatusCode.NotFound, "Department not found");
            return Request.CreateResponse(HttpStatusCode.OK, department);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create(Department department)
        {
            _departmentService.CreateDepartment(department);
            return Request.CreateResponse(HttpStatusCode.OK, department);
        }

        // POST: api/Department
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Department/5
        [HttpPut]
        [Route("")]
        public HttpResponseMessage Put(Department department)
        {
            _departmentService.UpdateDepartment(department);
            return Request.CreateResponse(HttpStatusCode.OK, department);
        }

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/Department/5
        [HttpDelete]
        [Route("{id:int?}")]
        public HttpResponseMessage Delete(int id)
        {
            _departmentService.DeleteDepartmentById(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
