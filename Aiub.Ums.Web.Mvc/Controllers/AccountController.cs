using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Web.Mvc.Models;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _service;

        public AccountController(IAuthenticationService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginVM() { UserId = "admin", Password = "admin"}); //Fake Data
            //return View(new LoginVM()); //Actual Model to be passed
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (_service.Authenticate(model.UserId, model.Password))
            {
                Session["UserId"] = model.UserId;

                if (model.UserId.ToLower().Equals("student"))
                    return RedirectToAction("Index", "StudentDashboard");
                return RedirectToAction("Index", "AdminDashboard");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}