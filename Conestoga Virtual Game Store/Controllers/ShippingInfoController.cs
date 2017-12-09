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
    public class ShippingInfoController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: ShippingInfo
        public ActionResult Index()
        {

            int user_id = Int32.Parse(TempData.Peek("user_id").ToString());

            var getUser = db.user_shipment_info.Where(r => r.user_id == user_id);
            return View(getUser.ToList());
        }

        // GET: ShippingInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shipment_id,user_id,address_1,address_2,city,province,country,postal_code,first_name,last_name")] user_shipment_info user_shipment_info)
        {
            if (ModelState.IsValid)
            {
                db.user_shipment_info.Add(user_shipment_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_shipment_info);
        }

        // GET: ShippingInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_shipment_info user_shipment_info = db.user_shipment_info.Find(id);
            if (user_shipment_info == null)
            {
                return HttpNotFound();
            }
            return View(user_shipment_info);
        }

        // POST: ShippingInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shipment_id,user_id,address_1,address_2,city,province,country,postal_code,first_name,last_name")] user_shipment_info user_shipment_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_shipment_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_shipment_info);
        }

        // GET: ShippingInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_shipment_info user_shipment_info = db.user_shipment_info.Find(id);
            if (user_shipment_info == null)
            {
                return HttpNotFound();
            }
            return View(user_shipment_info);
        }

        // POST: ShippingInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user_shipment_info user_shipment_info = db.user_shipment_info.Find(id);
            db.user_shipment_info.Remove(user_shipment_info);
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
