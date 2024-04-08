using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socialMedia)
        {
            db.TblSocialMedias.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var skill = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias socialMedia)
        {
            var value = db.TblSocialMedias.Find(socialMedia.SocialMediaId);
            value.SocialMediaName = socialMedia.SocialMediaName;
            value.Url = socialMedia.Url;
            value.Icon = socialMedia.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}