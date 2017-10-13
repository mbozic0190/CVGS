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
    public class ReviewsController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: Reviews
        public ActionResult Index()
        {
            //var reviews = db.reviews.Include(r => r.game_platforms).Include(r => r.user).Include(r => r.user1);

            var reviews = db.reviews.Where(a => a.validated_flag == "P").Include(r => r.game_platforms).Include(r => r.user).Include(r => r.user1);

            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id");
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag");
            ViewBag.validated_by = new SelectList(db.users, "user_id", "employee_flag");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "review_id,user_id,game_platform_id,review_text,validated_flag,validated_by")] review review)
        {
            if (ModelState.IsValid)
            {
                db.reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id", review.game_platform_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag", review.user_id);
            ViewBag.validated_by = new SelectList(db.users, "user_id", "employee_flag", review.validated_by);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id", review.game_platform_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag", review.user_id);
            ViewBag.validated_by = new SelectList(db.users, "user_id", "employee_flag", review.validated_by);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "review_id,user_id,game_platform_id,review_text,validated_flag,validated_by")] review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id", review.game_platform_id);
            ViewBag.user_id = new SelectList(db.users, "user_id", "employee_flag", review.user_id);
            ViewBag.validated_by = new SelectList(db.users, "user_id", "employee_flag", review.validated_by);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            review review = db.reviews.Find(id);
            db.reviews.Remove(review);
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

        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = db.reviews.Find(id);
            if (review != null)
            {
                string messageToUser = "";

                var query =
                    from rev in db.reviews
                    where rev.review_id == id
                    select rev;

                foreach (review rev in query)
                {
                    rev.validated_flag = "A";
                    messageToUser = rev.review_id.ToString();
                }

                try
                {
                    db.SaveChanges();
                    Response.Write("Review " + messageToUser + " Validated");

                }
                catch
                {

                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult Deny(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            review review = db.reviews.Find(id);
            if (review != null)
            {
                var query =
                    from rev in db.reviews
                    where rev.review_id == id
                    select rev;

                foreach (review rev in query)
                {
                    rev.validated_flag = "D";
                }

                try
                {
                    db.SaveChanges();
                }
                catch
                {

                }

            }
            return RedirectToAction("Index");
        }

    }
}
