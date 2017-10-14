using Conestoga_Virtual_Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conestoga_Virtual_Game_Store.Controllers
{
    public class EmployeeDashboardController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: EmployeeDashboard
        public ActionResult Index()
        {
            ViewBag.PendingReviews = (from row in db.reviews
                                      where row.validated_flag == "P"
                                      orderby row.validated_flag == "p"
                                      select row).Count();
            return View();
        }
    }
}