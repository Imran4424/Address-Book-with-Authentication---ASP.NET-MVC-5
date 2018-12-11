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

        // GET: Contacts / Index

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

        // GET: Contacts / Index

        public ActionResult Details(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            return View(contact);
        }

        // GET: Contacts / Delete

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Edit(int id)
        {


            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);

            return View(contact);
        }
    }
}