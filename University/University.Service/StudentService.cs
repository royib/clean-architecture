using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using University.Core.Service;
using University.Core;
using University.Core.Data;
using University.Core.Domain;
using System.Data.Entity;



namespace University.Service
{
    public class StudentService : IStudentService
    {
        private IRepository<Student> _studentRepository;
        private DbContext _context;

        public StudentService(IRepository<Student> Repository, DbContext Context)
        {
            _studentRepository = Repository;
            _context = Context;
        }
        
        //Get All The Students
        public IEnumerable<Core.Domain.Student> getAllStudents(int pageSize, int pageNumber, out int RecordCount, string orderByString)
        {
            var Students = _studentRepository.Table;
            var query = Students.OrderBy(s => s.StudentID);
            var StudentsPage = Enumerable.Empty<Student>().AsQueryable(); ;
            RecordCount = query.Count();
            if (string.IsNullOrEmpty(orderByString))
            {
                StudentsPage = query.Skip(pageSize * (pageNumber)).Take(pageSize);
            }
            else
            {
                StudentsPage = query.OrderBy(orderByString).Skip(pageSize * (pageNumber)).Take(pageSize);
            }
            return StudentsPage.ToList();
           
        }
    }
}
