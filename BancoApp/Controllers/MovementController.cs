using DataLayer;
using DataLayer.Entities;
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

            var al = db.Movements.Where(s => s.AccountId.Equals(ID));
            ICollection<Movement> icm = al.ToList();

            return View(icm);
        }

        public ActionResult CreateFirst(Guid id)
        {
            Movement mt = new Movement();
            mt.AccountId = id;

            using (var db = new EjercMVCDBContext())
            {
                mt.Account = db.Accounts.Find(id);
                db.SaveChanges();
            }

            return View(mt);
        }

        public ActionResult Create(int idMovement, Guid idAccount)
        {

            Movement mt = new Movement();
            mt.AccountId = idAccount;

            using (var db = new EjercMVCDBContext())
            {
                switch (idMovement)
                {
                    case 1:
                        mt.Type = MovementType.TRANSFER;
                        break;
                    case 2:
                        mt.Type = MovementType.DEPOSIT;
                        break;
                    case 3:
                        mt.Type = MovementType.EXTRACTION;
                        break;
                }
                mt.Date = DateTime.Now;

                //Para ver como muestro la vista
                ViewBag["Type"] = idMovement;

                db.SaveChanges();
            }

            return View(mt);
        }

        [HttpPost]
        public ActionResult Create(Movement mt)
        {
            return View();
        }
    }
}