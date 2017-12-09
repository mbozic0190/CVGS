using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Conestoga_Virtual_Game_Store.Models;

namespace Conestoga_Virtual_Game_Store.Controllers
{
    public class SignUpController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: SignUp/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            ViewBag.platform_id = new SelectList(db.platforms, "platform_id", "platform_name");
            return View();
        }

        // POST: SignUp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,employee_flag,display_name,first_name,last_name,birth_date,email,password,gender,promotional_emails,category_id,platform_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("index", "login");
            }

            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", user.category_id);
            ViewBag.platform_id = new SelectList(db.platforms, "platform_id", "platform_name", user.platform_id);
            return View(user);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
