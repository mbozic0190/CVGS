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
    public class GameCollectionController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: GameCollection
        public ActionResult Index()
        {

       //     var viewModel =
       //from pd in db.games
       //join p in db.game_collection on pd.game_id equals p.game_id
       //orderby p.user_id
       //select pd.game_name;
       //     return View(viewModel);
            return View(db.game_collection.ToList());
        }

        // GET: GameCollection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game_collection game_collection = db.game_collection.Find(id);
            if (game_collection == null)
            {
                return HttpNotFound();
            }
            return View(game_collection);
        }

        // GET: GameCollection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameCollection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "game_collection_id,user_id,game_id")] game_collection game_collection)
        {
            if (ModelState.IsValid)
            {
                db.game_collection.Add(game_collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game_collection);
        }

        // GET: GameCollection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game_collection game_collection = db.game_collection.Find(id);
            if (game_collection == null)
            {
                return HttpNotFound();
            }
            return View(game_collection);
        }

        // POST: GameCollection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "game_collection_id,user_id,game_id")] game_collection game_collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game_collection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game_collection);
        }

        // GET: GameCollection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game_collection game_collection = db.game_collection.Find(id);
            if (game_collection == null)
            {
                return HttpNotFound();
            }
            return View(game_collection);
        }

        // POST: GameCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            game_collection game_collection = db.game_collection.Find(id);
            db.game_collection.Remove(game_collection);
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
