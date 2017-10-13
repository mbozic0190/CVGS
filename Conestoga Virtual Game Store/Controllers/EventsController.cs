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
    public class EventsController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.events.Include(_ => _.user).Where(a => a.event_date >= DateTime.Today);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _event _event = db.events.Find(id);
            if (_event == null)
            {
                return HttpNotFound();
            }
            return View(_event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.created_by = 1;
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "event_id,event_date,created_by,event_name,event_description")] _event _event)
        {
            if (ModelState.IsValid)
            {
                _event.created_by = 1;
                db.events.Add(_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.created_by = 1;
            return View(_event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _event _event = db.events.Find(id);
            if (_event == null)
            {
                return HttpNotFound();
            }
            ViewBag.created_by = 1;
            return View(_event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "event_id,event_date,created_by,event_name,event_description")] _event _event)
        {
            if (ModelState.IsValid)
            {
                _event.created_by = 1;
                db.Entry(_event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.created_by = 1;
            return View(_event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _event _event = db.events.Find(id);
            if (_event == null)
            {
                return HttpNotFound();
            }
            return View(_event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _event _event = db.events.Find(id);
            db.events.Remove(_event);
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
