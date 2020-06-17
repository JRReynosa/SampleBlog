using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;
using Portfolio.ViewModels;

namespace Portfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Contacts/Index
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactViewModel contact)
        {
            if (!ModelState.IsValid) return View("Index");

            var sentMessage = new ContactService().SendMessage(contact);

            if (!sentMessage)
            {
                ViewBag.Message = "Sorry we are facing a problem here, try again.";
                return View("Index");
            }

            ViewBag.Message = "Thank you for contacting me.";
            return RedirectToAction("Index");
        }
    }
}
