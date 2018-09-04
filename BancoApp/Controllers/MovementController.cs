using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoApp.Controllers
{
    public class MovementController : Controller
    {
        // GET: Movement
        public ActionResult IndexFirst()
        {
            EjercMVCDBContext db = new EjercMVCDBContext();

            return View(db.Accounts.ToList());
        }

        public ActionResult Index(Guid ID)
        {
            EjercMVCDBContext db = new EjercMVCDBContext();

            return View(db.Movements.ToList());
        }
    }
}