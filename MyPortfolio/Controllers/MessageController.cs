using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }

        
        public ActionResult DeleteMessage(int id)
        {
            var message = db.TblMessages.Find(id);
            db.TblMessages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }

}