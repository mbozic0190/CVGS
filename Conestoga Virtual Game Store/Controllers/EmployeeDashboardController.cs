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
            int pendingReviews = (from row in db.reviews
                                      where row.validated_flag == "P"
                                      orderby row.validated_flag == "p"
                                      select row).Count();

            List<int> physicalOrders = (from od in db.order_details
                                        let qts = (from sod in db.order_shipment_details
                                                   where sod.order_detail_id == od.order_detail_id
                                                   select sod.qty_ship).Sum()
                                        where (od.physical_copy.Equals("y") || od.physical_copy.Equals("Y"))
                                        && od.qty_ordered > (qts ?? 0)
                                        select od.order_id).Distinct().ToList();


            int pendingOrders = db.orders.Where(a => physicalOrders.Contains(a.order_id)).Count();

            ViewBag.PendingOrders = pendingOrders.ToString() + " Order(s) Pending";
            ViewBag.PendingReviews = pendingReviews.ToString() + " Review(s) Pending";

            return View();
        }
    }
}