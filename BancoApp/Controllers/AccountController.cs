using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            EjercMVCDBContext db = new EjercMVCDBContext();
            
            return View(db.Accounts.ToList());
        }

        public ActionResult CreateFirst(Guid id)
        {
            Account ac = new Account();
            ac.CustomerId = id;
            ac.Credit = 0;

            using (var db = new EjercMVCDBContext())
            {
                ac.Customer = db.Customers.Find(id);
                db.SaveChanges();
            }

            return View(ac);
        }

        public ActionResult Create(int idAccount, Guid idCustomer)
        {
            Account ac = new Account();
            ac.CustomerId = idCustomer;
            ac.Credit = 0;

            using (var db = new EjercMVCDBContext())
            {
                ac.Customer = db.Customers.Find(idCustomer);

                switch (idAccount)
                {
                    case 1:
                        var at = db.AccountTypes.Where(s => s.Name.Equals("STARTER"));
                        ac.AccountType = at.First();
                        ac.AccountTypeId = at.First().Id;
                        break;
                    case 2:
                        var ap = db.AccountTypes.Where(s => s.Name.Equals("ADVANCE"));
                        ac.AccountType = ap.First();
                        ac.AccountTypeId = ap.First().Id;
                        break;
                    case 3:
                        var ae = db.AccountTypes.Where(s => s.Name.Equals("BUSSINESS"));
                        ac.AccountType = ae.First();
                        ac.AccountTypeId = ae.First().Id;
                        break;
                }
                db.SaveChanges();
            }

            return View(ac);
        }

        [HttpPost]
        public ActionResult Create(Account cl)
        {
            if (!ModelState.IsValid)
                return View();

            if (cl.Credit.Equals(null))
                cl.Credit = 0;

            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    cl.Customer = db.Customers.Find(cl.CustomerId);
                    cl.AccountType = db.AccountTypes.Find(cl.AccountTypeId); 
                    db.Accounts.Add(cl);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al asociar la cuenta - " + ex);
                return View();
            }

        }


        public ActionResult Edit(Guid id)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Account cl = db.Accounts.Find(id);
                    cl.Id = id;
                    return View(cl);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar la cuenta - " + ex);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account a)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Account ac = db.Accounts.Find(a.Id);
                    ac.Credit = a.Credit;
                    ac.AccountTypeId = a.AccountTypeId;
                    ac.CustomerId = a.CustomerId;
                    ac.AccountType = db.AccountTypes.Find(a.AccountTypeId);
                    ac.Customer = db.Customers.Find(a.CustomerId);
                    
                    db.SaveChanges();

                    ViewBag.Messagecl = "Account modificada con éxito.";

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar la cuenta - " + ex);
                return View();
            }
        }

        public ActionResult Details(Guid id)
        {
            using (var db = new EjercMVCDBContext())
            {
                Account ac = db.Accounts.Find(id);
                var j = db.AccountTypes.Find(ac.AccountTypeId);
                ac.AccountType.Name = j.Name.ToString();
                ac.Customer = db.Customers.Find(ac.CustomerId);

                return View(ac);
            }
        }


        public ActionResult Delete(Guid id)
        {
            using (var db = new EjercMVCDBContext())
            {
                Account ac = db.Accounts.Find(id);
                db.Accounts.Remove(ac);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }


        public ActionResult CreateMovement(Guid id)
        {
            return RedirectToAction("Create", "Movement", new { id });
        }
    }
}