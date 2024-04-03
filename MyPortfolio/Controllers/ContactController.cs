using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(TblContacts contacts)
        {
            db.TblContacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id)
        {
            var contact = db.TblContacts.Find(id);
            db.TblContacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContacts contacts)
        {
            var value = db.TblContacts.Find(contacts.ContactId);
            value.NameSurname = contacts.NameSurname;
            value.Address = contacts.Address;
            value.Phone = contacts.Phone;
            value.Email = contacts.Email;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}