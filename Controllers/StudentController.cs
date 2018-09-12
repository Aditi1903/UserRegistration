using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class StudentController : Controller
    {
        private ConnstrEntities obj = new ConnstrEntities();
        
        [HttpGet]
        public ActionResult StudentIndex(int Id)
        {
            var databyid = obj.Register.FirstOrDefault(x => x.UserId == Id);

            return View(databyid);
           
        }
        [HttpPost]
        public ActionResult StudentIndex(int Id, Register change)
        {
            try
            {
                // TODO: Add update logic here
                Register updateobj = obj.Register.FirstOrDefault(x => x.UserId == Id);
                updateobj.FirstName = change.FirstName;
                updateobj.LastName = change.LastName;
                updateobj.DOB = change.DOB;
                updateobj.City = change.City;
                updateobj.UserName = change.UserName;
                updateobj.Password = change.Password;
                updateobj.RoleName = change.RoleName;
                updateobj.UserImage = change.UserImage;
                obj.SaveChanges();
                return RedirectToAction("ViewDetails");

            }
            catch
            {
                return View();
            }
        }
            public ActionResult ViewDetails(int Id)
        {
            var databyId = obj.Register.ToList().FirstOrDefault(x => x.UserId == Id);

            return View(databyId);
        }
    }
       
    
}   
