using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using The_List_Of_Contacts.Models;
using System.Text.RegularExpressions;

namespace The_List_Of_Contacts.Controllers
{
    public class ContactController : Controller
    {
        private ContactsContext db = new ContactsContext();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            Contact contact = new Contact();

            var maxId = 0;

            foreach (var cont in db.Contacts)
	        {
		        if (cont.Id > maxId)
	            {
		             maxId = cont.Id;
	            }
	        }

            var contactNumber = maxId + 1;

            contact.ContactNumber = string.Format("CC-" + contactNumber.ToString("D6") + "-SL");
            return View(contact);
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (string.IsNullOrEmpty(contact.LastName))
            {
                ModelState.AddModelError("LastName", "Введите Фамилию");
            }
            if (string.IsNullOrEmpty(contact.PhoneNumber) || !new Regex(@"^\d{1}\(\d{3}\)\d{7}$").IsMatch(contact.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "Введите корректный телефон");
            }
            if (string.IsNullOrEmpty(contact.Email) || (contact.Email != null && !new Regex(@"\b[a-z0-9._]+@[a-z0-9.-]+\.[a-z]{2,4}\b").IsMatch(contact.Email)))
            {
                ModelState.AddModelError("Email", "Введите корректный Email");
            }

            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public void DeleteConfirmed(int id = 0)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}