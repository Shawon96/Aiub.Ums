using System.Web.Mvc;
using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Web.Mvc.Filters;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    [UserAuthentication]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
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
        public ActionResult Create(Department dept)
        {
            if (_service.Add(dept))
                return RedirectToAction("Index");
            return View(dept);
        }

        [HttpGet]
        public ActionResult Edit(Department dept)
        {
            return View(_service.GetById(dept.Id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Department dept)
        {
            if (_service.Edit(dept))
                return RedirectToAction("Index");
            return View(dept);
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
