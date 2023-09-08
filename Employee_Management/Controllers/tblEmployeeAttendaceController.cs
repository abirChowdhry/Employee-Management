using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee_Management.Controllers
{
    public class tblEmployeeAttendaceController : ApiController
    {

        [HttpPost]
        [Route("api/employee/attendance/insert")]
        public HttpResponseMessage Insert(tblEmployeeAttendanceDTO attendance)
        {
            try
            {
                var res = tblEmployeeAttendanceServices.Insert(attendance);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }


        //API04# Get monthly attendance report of all employee

        [HttpGet]
        [Route("api/employee/monthlyReport/{month}")]
        public HttpResponseMessage EmployeeMonthlyReport(int month)
        {
            try
            {
                var res = tblEmployeeAttendanceServices.monthlyReport(month);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
