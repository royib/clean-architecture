﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Core.Domain;

namespace University.Core.Service
{
    public interface IStudentService
    {
        IEnumerable<studentIndex> getAllStudents(int pageSize, int pageNumber, out int RecordCount, string orderByString);
        Student getStudentById(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        void CreateStudent(Student student);
    }
}
