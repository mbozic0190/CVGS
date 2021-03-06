﻿using System;
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
    public class GameDetailsController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: GameDetails
        public ActionResult Index()
        {
            var games = db.games.Include(g => g.category).Include(g => g.developer);
            return View(games.ToList());
        }

        // GET: GameDetails/Details/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost, ActionName("Search")]
        public ActionResult Search(string SearchGame)
        {
            string criteria = SearchGame;

            if (criteria != "")
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
