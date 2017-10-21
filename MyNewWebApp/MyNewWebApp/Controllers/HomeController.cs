using MyNewWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MyNewWebApp.Controllers
{
    public class HomeController : Controller
    {
        TankContext db = new TankContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AllTanks()
        {
            return View(db.Tanks);
        }

        public ActionResult AddTank()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTank(Tank t, HttpPostedFileBase uploadImage)
        {
            
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                // установка массива байтов
                t.Image = imageData;

                db.Tanks.Add(t);
                db.SaveChanges();

                return RedirectToAction("AllTanks");
            }
            else if (uploadImage == null)
            {
                Image img = Image.FromFile(@"C:\Users\roamik\Documents\Visual Studio 2017\Projects\MyNewWebApp\MyNewWebApp\Images\dummy.jpg");
                byte[] byteArr;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    byteArr = ms.ToArray();
                }

                t.Image = byteArr;
                db.Tanks.Add(t);
                db.SaveChanges();

                return RedirectToAction("AllTanks");
            }
            return View(t);

        }

        [HttpGet]
        public ActionResult EditTank(int id)
        {
            Tank tank = db.Tanks.Find(id);
            if (tank != null)
            {
                return View(tank);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult EditTank(Tank tank, HttpPostedFileBase uploadImg)
        {
            if (ModelState.IsValid && uploadImg != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadImg.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImg.ContentLength);
                }
                // установка массива байтов
                tank.Image = imageData;

                db.Entry(tank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AllTanks");
            }
            else if (uploadImg == null)
            {
                db.Entry(tank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AllTanks");
            }
            return View(tank);

        }
    }
}