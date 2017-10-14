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
    public class WishlistReportController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: WishlistReport
        public ActionResult Index()
        {
            var wishlists = db.wishlists.Include(w => w.game).Include(w => w.user);
            return View(wishlists.ToList());
        }

        // GET: WishlistReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wishlist wishlist = db.wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
        }

        // GET: WishlistReport/Create
        public ActionResult Create()
        {
            ViewBag.game_id = new SelectList(db.games, "game_id", "game_name");
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag");
            return View();
        }

        // POST: WishlistReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wishlist_id,user_id,game_id")] wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                db.wishlists.Add(wishlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.game_id = new SelectList(db.games, "game_id", "game_name", wishlist.game_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag", wishlist.user_id);
            return View(wishlist);
        }

        // GET: WishlistReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wishlist wishlist = db.wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.game_id = new SelectList(db.games, "game_id", "game_name", wishlist.game_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag", wishlist.user_id);
            return View(wishlist);
        }

        // POST: WishlistReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wishlist_id,user_id,game_id")] wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wishlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.game_id = new SelectList(db.games, "game_id", "game_name", wishlist.game_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag", wishlist.user_id);
            return View(wishlist);
        }

        // GET: WishlistReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wishlist wishlist = db.wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
        }

        // POST: WishlistReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wishlist wishlist = db.wishlists.Find(id);
            db.wishlists.Remove(wishlist);
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
