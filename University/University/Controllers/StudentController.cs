using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Core.Service;
using University.Core.Domain;
using System.Data;
using University.Models;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        //
        // GET: /Student/

        public ActionResult Index()
        {

            return View();
        } 

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            var student = _studentService.getStudentById(id);
          //  var apiStudent = AutoMapper.Mapper.Map<Student, StudentDto>(student);
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "StudentID")]Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    _studentService.CreateStudent(student);                   
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index");
            //return Content(@"<script>$('#myModal').modal('hide')</script>");
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id)
        {

            var Student = _studentService.getStudentById(id);
            return View(Student);
        }
        public ActionResult Edit1(int id)
        {

            var Student = _studentService.getStudentById(id);
            return View(Student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.UpdateStudent(student);                    
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _studentService.DeleteStudent(_studentService.getStudentById(id));
               
            }
            catch
            {
               
            }
            return RedirectToAction("Index");
        }

        //
        //// POST: /Student/Delete/5

        //[HttpPost]
        //public ActionResult Delete(Student student)
        //{
           
        //}
    }
}
