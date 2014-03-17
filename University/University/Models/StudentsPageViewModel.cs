using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Core.Domain;


namespace University.Models.Students
{
    public class StudentsPageViewModel
    {
        public IEnumerable<StudentDto> Students;
        public int PageSize;
        public int PageNumber;
        public int RecordCount;
    }
}