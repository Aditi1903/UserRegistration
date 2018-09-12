using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        private ConnstrEntities obj = new ConnstrEntities();
        public ActionResult ShowListonly()
        {
            var data = obj.Register.ToList();
            return View(data);
        }
    }
}