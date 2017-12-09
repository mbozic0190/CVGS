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
    public class ProfileController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: Profile
        public ActionResult Index()
        {
            int user_id = Int32.Parse(TempData.Peek("user_id").ToString());

            var getUser = db.users.Where(r => r.user_id == user_id);
            return View(getUser.ToList());

            //var users = db.users.Include(u => u.category).Include(u => u.platform);
            //return View(users.ToList());
        }

        // GET: Profile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            ViewBag.platform_id = new SelectList(db.platforms, "platform_id", "platform_name");
            return View();
        }

        // POST: Profile/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", user.category_id);
            ViewBag.platform_id = new SelectList(db.platforms, "platform_id", "platform_name", user.platform_id);
            return View(user);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", user.category_id);
            ViewBag.platform_id = new SelectList(db.platforms, "platform_id", "platform_name", user.platform_id);
            return View(user);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,employee_flag,display_name,first_name,last_name,birth_date,email,password,gender,promotional_emails,category_id,platform_id")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", user.category_id);
            ViewBag.platform_id = new SelectList(db.platforms, "platform_id", "platform_name", user.platform_id);
            return View(user);
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
