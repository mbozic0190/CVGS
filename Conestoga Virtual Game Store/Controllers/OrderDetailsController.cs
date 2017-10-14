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
            var order_details = (from od in db.order_details
                                 let qts = (from sod in db.order_shipment_details
                                            where sod.order_detail_id == od.order_detail_id
                                            select sod.qty_ship).Sum()
                                 where (od.physical_copy.Equals("y") || od.physical_copy.Equals("Y"))
                                 && od.qty_ordered > (qts ?? 0) && od.order_id == id
                                 select od);

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

        [HttpPost, ActionName("CreateShipment")]
        public ActionResult CreateShipment(IEnumerable<order_details> order_details)
        {
            if (ModelState.IsValid)
            {
                var tempShipment = new order_shipments();
                var tempShipmentDetails = new order_shipment_details();

                tempShipment.order_id = order_details.First().order_id;
                tempShipment.shipment_date = DateTime.Today;
                tempShipment.shipped_by = 1;

                db.order_shipments.Add(tempShipment);
                db.SaveChanges();

                int id = tempShipment.order_shipment_id;

                foreach (var item in order_details)
                {
                    tempShipmentDetails.order_shipment_id = id;
                    tempShipmentDetails.order_detail_id = item.order_detail_id;
                    tempShipmentDetails.qty_ship = item.qty_ship;

                    db.order_shipments.Add(tempShipment);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index","Orders",null);
        }
    }
}
