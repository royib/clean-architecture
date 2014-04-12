using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.Core.Service;
using University.Models;
using University.Core.Domain;
using System.IO;
using System.Web;

namespace University.Controllers
{
 
    //web api controller for students views
    public class StudentsApiController : ApiController
    {
        private IStudentService _studentService;

        public StudentsApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public studentsGridDto GetStudents(int pageSize = 3, int pageNumber = 1 )
        {
            string orderby = "";
            int RecordCount = 0; 
            //if (this.HttpContext.Request.Params["$orderby"] != null)
            //    orderby = this.HttpContext.Request.Params["$orderby"].ToString();
            orderby = Request.GetQueryString("$orderby");
            var Students = _studentService.getAllStudents(pageSize, pageNumber, out RecordCount, orderby);
            //map to student data transfer object
            //IEnumerable<studentIndex> apiStudents = Mapper.Map<IEnumerable<Student>, IEnumerable<studentIndex>>(Students);
            var studentPage = new studentsGridDto { Students = Students, PageSize = pageSize, PageNumber = pageNumber, RecordCount = RecordCount };

            return studentPage;
        }
    }
}
