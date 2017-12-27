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
    public class ShoppingCartController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View(db.shopping_cart.ToList());
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopping_cart shopping_cart = db.shopping_cart.Find(id);
            if (shopping_cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_cart);
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shopping_cart_id,user_id,platform_id,quantity")] shopping_cart shopping_cart)
        {
            if (ModelState.IsValid)
            {
                db.shopping_cart.Add(shopping_cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopping_cart);
        }

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopping_cart shopping_cart = db.shopping_cart.Find(id);
            if (shopping_cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_cart);
        }

        // POST: ShoppingCart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shopping_cart_id,user_id,platform_id,quantity")] shopping_cart shopping_cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopping_cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopping_cart);
        }

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopping_cart shopping_cart = db.shopping_cart.Find(id);
            if (shopping_cart == null)
            {
                return HttpNotFound();
            }
            return View(shopping_cart);
        }

        // POST: ShoppingCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shopping_cart shopping_cart = db.shopping_cart.Find(id);
            db.shopping_cart.Remove(shopping_cart);
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
