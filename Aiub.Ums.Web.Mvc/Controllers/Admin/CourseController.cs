using System.Web.Mvc;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Web.Mvc.Filters;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    [UserAuthentication]
    public class CourseController : Controller
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (_service.Add(course))
                return RedirectToAction("Index");
            return View(course);
        }

        [HttpGet]
        public ActionResult Edit(Course dept)
        {
            return View(_service.GetById(dept.Id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Course course)
        {
            if (_service.Edit(course))
                return RedirectToAction("Index");
            return View(course);
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
