using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.Domain;

namespace University.Core.Service
{
    public interface IStudentService
    {
        IEnumerable<Student> getAllStudents(int pageSize, int pageNumber, out int RecordCount, string orderByString);
        Student getStudentById(int id);
    }
}
