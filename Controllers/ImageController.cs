using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    public class ImageController : Controller
    {
       [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddImage(Image ImageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(ImageModel.ImageFile.FileName);
            string extension = Path.GetExtension(ImageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            ImageModel.ImagePath = "~/User-Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/User-Image/"), fileName);
            ImageModel.ImageFile.SaveAs(fileName);
            using (ConnstrEntities db = new ConnstrEntities())
            {
                db.Images.Add(ImageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("ViewDetails");
        }

    }
}