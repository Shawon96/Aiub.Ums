using System.Collections.Generic;
using System.Web.Mvc;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Web.Mvc.Filters;
using Aiub.Ums.Web.Mvc.Models;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    [UserAuthentication]
    public class SectionController : Controller
    {
        private readonly ISectionService _service;
        private ICourseService _courseService;

        public SectionController(ISectionService service, ICourseService courseService)
        {
            this._service = service;
            this._courseService = courseService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ICollection<SectionCourseVM> model = new List<SectionCourseVM>();

            foreach (var section in _service.GetAll())
            {
                model.Add(new SectionCourseVM()
                {
                    Section = section,
                    Course = _courseService.GetById(section.CourseId)
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Section section = _service.GetById(id);
            SectionCourseVM model = new SectionCourseVM()
            {
                Section = section,
                Course = _courseService.GetById(section.CourseId)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Courses = _courseService.GetAll();
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(Section section)
        {
            if (_service.Add(section))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Courses = _courseService.GetAll();
                return View(section);
            }
        }

        [HttpGet]
        public ActionResult Edit(Section section)
        {
            ViewBag.Courses = _courseService.GetAll();
            return View(_service.GetById(section.Id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Section section)
        {
            if (_service.Edit(section))
                return RedirectToAction("Index");
            else
            {
                ViewBag.Courses = _courseService.GetAll();
                return View(section);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_service.GetById(id));
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            if (_service.Remove(id))
                return RedirectToAction("Index");
            else
                return View(_service.GetById(id));
        }
    }
}
