using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Contacts / Index

        public ActionResult Index()
        {
            var contacts = _context.Contacts.ToList();

            return View(contacts);
        }

        // GET: Contacts / New

        public ActionResult New()
        {
            var newContact = new Contact();

            return View("ContactForm", newContact);
        }

        [HttpPost]

        public ActionResult Save(Contact contact)
        {
            _context.Contacts.Add(contact); // to add the data in memory
            _context.SaveChanges(); // to save the data to database

            return RedirectToAction("Index", "Contacts");
        }

        // GET: Contacts / Details

        public ActionResult Details(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            return View(contact);
        }

        // GET: Contacts / Delete

        public ActionResult Delete(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            _context.Contacts.Remove(contact);

            _context.SaveChanges();

            return RedirectToAction("Index", "Contacts");
        }

        // GET: Contacts / Edit

        public ActionResult Edit(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            return View("UpdateForm", contact);
        }

        [HttpPost]

        public ActionResult Update(Contact contact)
        {
            var contactInDb = _context.Contacts.Single(c => c.Id == contact.Id);

            contactInDb.FullName = contact.FullName;
            contactInDb.NickName = contact.NickName;
            contactInDb.Mobile = contact.Mobile;
            contactInDb.Address = contact.Address;
            contactInDb.Email = contact.Email;
            contactInDb.Birthdate = contact.Birthdate;


            _context.SaveChanges();

            return RedirectToAction("Details", "Contacts", contactInDb);
        }
    }
}