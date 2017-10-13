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
    public class OrderDetailsController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: OrderDetails
        public ActionResult Index(int id)
        {
            var order_details = db.order_details.Where(a => a.order_id == id).Include(o => o.game_platforms).Include(o => o.order);
            return View(order_details.ToList());
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_details order_details = db.order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id");
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_id");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_detail_id,order_id,game_platform_id,physical_copy,qty_ordered")] order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.order_details.Add(order_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id", order_details.game_platform_id);
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_id", order_details.order_id);
            return View(order_details);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_details order_details = db.order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id", order_details.game_platform_id);
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_id", order_details.order_id);
            return View(order_details);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_detail_id,order_id,game_platform_id,physical_copy,qty_ordered")] order_details order_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.game_platform_id = new SelectList(db.game_platforms, "game_platform_id", "game_platform_id", order_details.game_platform_id);
            ViewBag.order_id = new SelectList(db.orders, "order_id", "order_id", order_details.order_id);
            return View(order_details);
        }

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_details order_details = db.order_details.Find(id);
            if (order_details == null)
            {
                return HttpNotFound();
            }
            return View(order_details);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_details order_details = db.order_details.Find(id);
            db.order_details.Remove(order_details);
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
