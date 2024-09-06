using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneToOneStudentDemo.Data;
using OneToOneStudentDemo.Models;

namespace OneToOneStudentDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }

        public ActionResult Create()
        {

        return View(); }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student.Course == null)
            {
                student.Course = new Course();
            }
            student.Course.Student = student;
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Save(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(student);
        }
        public ActionResult Edit(int id)
        {
            using(var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(u=>u.Id == id);
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            
            using(var session= NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    student.Course.Student = student;
                    session.Update(student);
                    txn.Commit();
                    return RedirectToAction("Index");   
                }
            }
        }
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                session.Delete(student);
                return View(student);


            }
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteProduct(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var student = session.Get<Student>(id);
                    session.Delete(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}