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
        private ConnstrEntities1 obj = new ConnstrEntities1();
        // private ConnstrEntities1 obj = new ConnstrEntities1();
        // GET: Student
        //public ActionResult AddImage()
        //{
        //    return View(); 
        //}
        //[HttpPost]
        //public ActionResult AddImage(Register ImageModel)
        //{
        //    string fileName = Path.GetFileNameWithoutExtension(ImageModel.ImageFile.FileName);
        //    string extension = Path.GetExtension(ImageModel.ImageFile.FileName);
        //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //    ImageModel.UserImage = "~/User-Images/" + fileName;
        //    fileName = Path.Combine(Server.MapPath("~/User-Images/"), fileName);
        //    ImageModel.ImageFile.SaveAs(fileName);
        //    using (ConnstrEntities1 db = new ConnstrEntities1())
        //    {
        //        db.Registers.Add(ImageModel);
        //        db.SaveChanges();
        //    }
        //    ModelState.Clear();
        //    return RedirectToAction("ViewDetails");
        //}

        //[HttpGet]
        //public ActionResult View(int Id)
        //{
        //    Register imageModel = new Register();
        //    using (ConnstrEntities1 db = new ConnstrEntities1())
        //    {
        //        imageModel = db.Registers.Where(x => x.UserId == Id).FirstOrDefault();
        //    }
        //    return View(imageModel);
        //}

        //Get Student Details
        //public ActionResult ViewDetails(string name)
        //{
        //    {
        //        var dataOfStudent = obj.Register.ToList().FirstOrDefault(x => x.UserName == name);

        //        return View(dataOfStudent);
        //    }

        //}
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
        public ActionResult StudentProfile()
        {
           
            return View();
        }
            public ActionResult ViewDetails(int Id)
        {
            var databyId = obj.Register.ToList().FirstOrDefault(x => x.UserId == Id);

            return View(databyId);
        }
    }
       
    
}   
