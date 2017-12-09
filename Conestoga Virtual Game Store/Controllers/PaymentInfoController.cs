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
    public class PaymentInfoController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: PaymentInfo
        public ActionResult Index()
        {
            int user_id = 1;

            var getUser = db.user_payment_info.Where(r => r.user_id == user_id);
            return View(getUser.ToList());
            //return View(db.user_payment_info.ToList());
        }

        // GET: PaymentInfo/Create
        public ActionResult Create()
        {
            ViewBag.payment_type_id = new SelectList(db.payment_types, "payment_type_id", "payment_type_description");
            return View();
        }

        // POST: PaymentInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "payment_id,user_id,payment_type_id,card_number,address_1,address_2,city,province,country,postal_code,first_name,last_name")] user_payment_info user_payment_info)
        {
            if (ModelState.IsValid)
            {
                db.user_payment_info.Add(user_payment_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.payment_type_id = new SelectList(db.payment_types, "payment_type_id", "payment_type_description", user_payment_info.payment_type_id);
            return View(user_payment_info);
        }

        // GET: PaymentInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_payment_info user_payment_info = db.user_payment_info.Find(id);
            if (user_payment_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.payment_type_id = new SelectList(db.payment_types, "payment_type_id", "payment_type_description");
            return View(user_payment_info);
        }

        // POST: PaymentInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "payment_id,user_id,payment_type_id,card_number,address_1,address_2,city,province,country,postal_code,first_name,last_name")] user_payment_info user_payment_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_payment_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.payment_type_id = new SelectList(db.payment_types, "payment_type_id", "payment_type_description", user_payment_info.payment_type_id);
            return View(user_payment_info);
        }

        // GET: PaymentInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_payment_info user_payment_info = db.user_payment_info.Find(id);
            if (user_payment_info == null)
            {
                return HttpNotFound();
            }
            return View(user_payment_info);
        }

        // POST: PaymentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_payment_info user_payment_info = db.user_payment_info.Find(id);
            db.user_payment_info.Remove(user_payment_info);
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
