using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Web.Mvc.Filters;
using Aiub.Ums.Web.Mvc.Models;
using Microsoft.Ajax.Utilities;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    [UserAuthentication]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _service;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseSrvice;
        private readonly ISectionService _sectionService;

        public RegistrationController(IRegistrationService service, IStudentService studentService, ICourseService courseSrvice, ISectionService sectionService)
        {
            this._service = service;
            this._studentService = studentService;
            this._courseSrvice = courseSrvice;
            this._sectionService = sectionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<CourseSectionsStudentsVM> model = new List<CourseSectionsStudentsVM>();
            foreach (var course in _courseSrvice.GetAll())
            {
                CourseSectionsStudentsVM csm = new CourseSectionsStudentsVM();
                csm.Course = course;
                //csm.Sections = new List<SectionStudentVM>();

                List<Section> offeredSections = _sectionService.GetAll().Where(s => s.CourseId == course.Id).ToList();
                foreach (var section in offeredSections)
                {
                    SectionStudentsVM ssm = new SectionStudentsVM();
                    ssm.Section = section;

                    var result = from std in _studentService.GetAll()
                                 join reg in _service.GetAll() on std.Id equals reg.StudentId
                                 where section.Id==reg.SectionId
                                 select std;

                    ssm.Students = result.ToList();

                    csm.Sections.Add(ssm);
                }
                model.Add(csm);
            }

            return View(model);
        }

        [HttpPost]
        public JsonResult CourseSections()
        {
            IEnumerable<CourseSectionsVM> model = new List<CourseSectionsVM>();

            foreach (var course in _courseSrvice.GetAll())
            {
                CourseSectionsVM cs = new CourseSectionsVM();
                cs.Course = course;
                cs.Sections = _sectionService.GetAll().Where(s => s.CourseId == course.Id).ToList();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult Create(Registration reg)
        //{
        //    Registration reg1 = _service.GetRegistrationBySectionId(reg.SectionId).SingleOrDefault(r => r.StudentId == reg.StudentId);
        //    if (reg1 != null)
        //    {
        //        if (_service.Remove(reg1.Id))
        //            return Content("Unregistered");
        //        return Content("Error");
        //    }
        //    if (_service.Add(reg))
        //        return Content("Registered");
        //    return View(reg);
        //}

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View(new StudentSectionsVM());
        //}

        //[HttpPost]
        //[Route("Registration/Register/{StudentId}")]
        //public ActionResult Register(string studentId)
        //{
        //    StudentSectionsVM model = new StudentSectionsVM();
        //    model.Student = _studentService.GetById(studentId);
        //    model.Sections = _service.GetSectionsByStudentId(studentId).ToList();
        //    return View(model);
        //}

        //[HttpPost]
        //[Route("Registration/Register/{StudentId}/{SectionId}")]
        //public ActionResult Register(string studentId, int sectionId)
        //{
        //    StudentSectionsVM model = new StudentSectionsVM();
        //    model.Student = _studentService.GetById(studentId);
        //    model.Sections = _service.GetSectionsByStudentId(studentId).ToList();
        //    return View(model);
        //}



        [HttpGet]
        public ActionResult AddStudentToSection(int sectionId)
        {
            SectionStudentsVM model = new SectionStudentsVM();
            model.Section = _sectionService.GetById(sectionId);
            model.Students = _service.GetStudentsBySectionId(sectionId).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddStudentToSection(Registration reg) //formatted student id: Bob [18-12345-2]
        {
            reg.StudentId = reg.StudentId.Substring(reg.StudentId.IndexOf("[")+1, 10);
            _service.Add(reg);
            return RedirectToAction("AddStudentToSection", new {sectionId = reg.SectionId});
        }

        [HttpGet]
        [Route("Registration/Delete/{StudentId}/{SectionId}")]
        public ActionResult Delete(Registration reg)
        {
            return View(_service.GetByStudentAndSectionId(reg.StudentId, reg.SectionId));
        }

        [HttpPost]
        [ActionName("Delete")]
        [Route("Registration/Delete/{StudentId}/{SectionId}")]
        public ActionResult DeletePost(Registration reg)
        {
            if (_service.Remove(reg.Id))
                return RedirectToAction("AddStudentToSection", new {sectionId = reg.SectionId});
            else
                return View(_service.GetById(reg.Id));
        }
    }
}
