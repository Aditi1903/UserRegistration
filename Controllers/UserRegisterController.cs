using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;
using static System.Net.WebRequestMethods;

namespace UserRegistration.Controllers
{
    public class UserRegisterController : Controller
    {
        public string RoleName { get; private set; }

        // GET: UserRegister
        public ActionResult Index()
        {
            using (ConnstrEntities db = new ConnstrEntities())
            {
                return View(db.Register.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register account)
        {
            if (ModelState.IsValid)
            {
                using (ConnstrEntities db = new ConnstrEntities())
                {
                    db.Register.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.UserId + " " + account.FirstName + " " + account.LastName + " " + account.DOB + " " + account.City + " " + account.UserName + " " + account.Password + " "+account.RoleName + " " +account.UserImage + "successfully Registered";

            }

            return RedirectToAction("Login");

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Register student)
        {
            using (ConnstrEntities db = new ConnstrEntities())
            {
                var form = db.Register.Where(u => u.UserName == student.UserName && u.Password == student.Password).FirstOrDefault();
                if (form != null)
                    if (form.RoleName == "Admin")
                    {
                        return RedirectToAction("ShowList", "Admin");
                    }
                   else if(form.RoleName == "Teacher")
                    {
                        return RedirectToAction("ShowListOnly", "Teacher");
                    }
                   else if(form.RoleName == "Student")
                    {
                        return RedirectToAction("ViewDetails", "Student");
                    }
                    //    {
                    //        Session["UserId"] = form.UserId.ToString();
                    //        Session["FirstName"] = form.FirstName.ToString();
                    //    }
                    //    else
                    //    {
                    //        ModelState.AddModelError("", "Wrong Information");
                    //    }
                    //}
                    else
                    {
                        return RedirectToAction("Login");

                    }
                return View("Login");
            }
          }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login");
        }
        //public ActionResult AddImage()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddImage(Register ImageModel)
        //{
        //    string fileName = Path.GetFileNameWithoutExtension(ImageModel.ImageFile.FileName);
        //    string extension = Path.GetExtension(ImageModel.ImageFile.FileName);
        //    ImageModel.UserImage = "~/User-Images/" + fileName;
        //    fileName = Path.Combine(Server.MapPath("~/User-Images/"), fileName);
        //    ImageModel.ImageFile.SaveAs(fileName);
        //    using (ConnstrEntities1 db = new ConnstrEntities1())
        //    {
        //        db.Registers.Add(ImageModel);
        //        db.SaveChanges();
        //    }
        //    ModelState.Clear();
        //    return View();
        //}

    }
}








