using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee_Management.Controllers
{
    public class tblEmployeeController : ApiController
    {
        [HttpPost]
        [Route("api/employee/insert")]
        public HttpResponseMessage Insert(tblEmployeeDTO employee)
        {
            try
            {
                var res = tblEmployeeServices.Insert(employee);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        //API01# Update an employee’s Employee Name and Code [Don't allow duplicate employee code]

        [HttpPost]
        [Route("api/employee/update/{employeeId}")]
        public HttpResponseMessage Update(tblEmployeeDTO employeeId)
        {
            try
            {
                var res = tblEmployeeServices.Update(employeeId);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        //API02# Get employee who has 3rd highest salary

        [HttpGet]
        [Route("api/employee/thirdHighestSalary")]
        public HttpResponseMessage GetThirdHighestSalary()
        {
            try
            {
                var res = tblEmployeeServices.GetThirdHighestSalary();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        //API03# Get all employee based on maximum to minimum salary who has not any absent record

        [HttpGet]
        [Route("api/employee/maxToMinSalByAbsent")]
        public HttpResponseMessage MaxToMinByAbsent()
        {
            try
            {
                var res = tblEmployeeServices.MaxToMinByAbsent();
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        //API05# Get a hierarchy from an employee based on his supervisor

        [HttpGet]
        [Route("api/employee/hierarchy/{employeeId}")]
        public HttpResponseMessage employeeHierarchy(int employeeId)
        {
            try
            {
                var res = tblEmployeeServices.employeeHierarchy(employeeId);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
