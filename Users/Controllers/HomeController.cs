using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users.Controllers.DataLayer;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (UsersContext contex = new UsersContext())
            {
                List<User> users = contex.users.ToList();
                return View(users);
            }
        }
    }
}