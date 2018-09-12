using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class AdminController : Controller
    {
        private ConnstrEntities obj = new ConnstrEntities();
        // GET: Admin
        public ActionResult ShowList()
        {
            var data = obj.Register.ToList();
            return View(data);
        }
        //Insert data
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Register collection)
        {
            try
            {
                // TODO: Add insert logic here
                obj.Register.Add(collection);
                obj.SaveChanges();
                return RedirectToAction("ShowList");
            }
            catch
            {
                return View();
            }
        }
        //get student details
        public ActionResult Details(int Id)
        {
            var databyId = obj.Register.ToList().Single(x => x.UserId == Id);

            return View(databyId);
        }

        //Delete student details
        public ActionResult Delete(int Id)
        {

            var databyId = obj.Register.Single(x => x.UserId == Id);

            return View(databyId);
        }


        [HttpPost]
        public ActionResult Delete(int Id, Register collection)
        {
            try
            {
                var data = obj.Register.Single(x => x.UserId == Id);
                obj.Register.Remove(data);
                obj.SaveChanges();

                return RedirectToAction("ShowList");
            }
            catch
            {
                return View();
            }

        }
    }
}
