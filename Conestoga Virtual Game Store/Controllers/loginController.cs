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
    public class LoginController : Controller
    {
        private CVGSModel db = new CVGSModel();

        // GET: login
        public ActionResult Index()
        {
            TempData.Add("login_error", "");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "user_id,employee_flag,display_name,first_name,last_name,birth_date,email,password,gender,promotional_emails,category_id,platform_id")] user user)
        {
            bool found = false;
            bool password = false;

            IQueryable tempQuery = from a in db.users
                               where a.email.ToUpper().Equals(user.email.ToUpper())
                               select a;
            foreach (var a in tempQuery)
            {
                user tempUser = (user)a;

                found = true;
                if(tempUser.password == user.password)
                {
                    password = true;
                    TempData.Add("user_id",tempUser.user_id);
                    TempData.Add("employee_flag",tempUser.employee_flag);
                    TempData.Add("display_name",tempUser.display_name);
                    TempData.Add("email", tempUser.email);
                    TempData.Add("first_name", tempUser.first_name);
                    TempData.Add("last_name", tempUser.last_name);
                }
            }
            
            if (found && password)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (!found)
            {
                TempData.Add("login_error", "User not found.");
            }
            else
            {
                TempData.Add("login_error", "Incorrect password.");
            }

            return View();
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
