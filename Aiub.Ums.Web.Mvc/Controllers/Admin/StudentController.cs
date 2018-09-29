using System.Web.Mvc;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;
using System.Collections.Generic;
using Aiub.Ums.Web.Mvc.Filters;
using Aiub.Ums.Web.Mvc.Models;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    [UserAuthentication]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly IDepartmentService _deptService;

        public StudentController(IStudentService service, IDepartmentService deptService)
        {
            this._service = service;
            this._deptService = deptService;
        }

        [HttpPost]
        //[Route("Student/Search")]
        public JsonResult Search(string key)
        {
            return Json(_service.GetByIdOrName(key), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            ICollection<StudentDepartmentVM> model = new List<StudentDepartmentVM>();

            foreach (var student in _service.GetAll())
            {
                model.Add(new StudentDepartmentVM()
                {
                    Student = student, Department = _deptService.GetById(student.DepartmentId)
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            Student student = _service.GetById(id);
            StudentDepartmentVM model = new StudentDepartmentVM()
            {
                Student = student,
                Department = _deptService.GetById(student.DepartmentId)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departments = _deptService.GetAll();
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(Student std)
        {
            if (_service.Add(std))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Departments = _deptService.GetAll();
                return View(std);
            }
        }

        [HttpGet]
        public ActionResult Edit(Student std)
        {
            ViewBag.Departments = _deptService.GetAll();
            return View(_service.GetById(std.Id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Student std)
        {
            if (_service.Edit(std))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Departments = _deptService.GetAll();
                return View(std);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View(_service.GetById(id));
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(string id)
        {
            if (_service.Remove(id))
                return RedirectToAction("Index");
            else
                return View(_service.GetById(id));
        }
    }
}
