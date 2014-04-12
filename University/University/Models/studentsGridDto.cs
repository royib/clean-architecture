using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Core.Domain;

namespace University.Models
{
    public class studentsGridDto
    {
        public IEnumerable<studentIndex> Students;
        public int PageSize;
        public int PageNumber;
        public int RecordCount;
    }
}