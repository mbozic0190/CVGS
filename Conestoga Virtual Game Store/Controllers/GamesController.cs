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
    public class GamesController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: Games
        public ActionResult Index()
        {
            var games = db.games.Include(g => g.category).Include(g => g.developer);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            ViewBag.developer_id = new SelectList(db.developers, "developer_id", "developer_name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "game_id,game_name,description,release_date,price,category_id,developer_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", game.category_id);
            ViewBag.developer_id = new SelectList(db.developers, "developer_id", "developer_name", game.developer_id);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", game.category_id);
            ViewBag.developer_id = new SelectList(db.developers, "developer_id", "developer_name", game.developer_id);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "game_id,game_name,description,release_date,price,category_id,developer_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", game.category_id);
            ViewBag.developer_id = new SelectList(db.developers, "developer_id", "developer_name", game.developer_id);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            game game = db.games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            game game = db.games.Find(id);
            db.games.Remove(game);
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

        [HttpPost, ActionName("Search")]
        public ActionResult Search(string SearchName)
        {
            string criteria = SearchName;

            if(criteria != "")
            {
                var searchGames = db.games.Where(a => a.game_name.Contains(criteria)).Include(g => g.category).Include(g => g.developer);
                return View("index", searchGames.ToList());
            }
            else
            {
                var games = db.games.Include(g => g.category).Include(g => g.developer);
                return View("index", games.ToList());
            }

        }
    }
}
