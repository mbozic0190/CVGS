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
    public class EventDetailsController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: EventDetails
        public ActionResult Index()
        {
            var events = db.events.Include(_ => _.user);
            return View(events.ToList());
        }

        // GET: EventDetails/Details/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost, ActionName("Search")]
        public ActionResult Search(string SearchEvent)
        {
            string criteria = SearchEvent;

            if (criteria != "")
            {
                var searchEvents = db.events.Where(a => a.event_name.Contains(criteria));
                return View("index", searchEvents.ToList());
            }
            else
            {
                var events = db.events;
                return View("index", events.ToList());
            }

        }
    }
}
