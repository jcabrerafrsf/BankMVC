using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            EjercMVCDBContext db = new EjercMVCDBContext();

            return View(db.Customers.ToList());
        }

        public ActionResult Create(Guid id)
        {
            Customer cs = new Customer();
            cs.BankId = id;

            using (var db = new EjercMVCDBContext())
            {
                cs.Bank = db.Banks.Find(id);
                db.SaveChanges();

            }          

            return View(cs);
        }

        [HttpPost]
        public ActionResult Create(Customer cl, Guid id)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    cl.BankId = id;
                    db.Customers.Add(cl);
                    db.SaveChanges();

                    ViewBag.Messagecl = "Cliente agregado con éxito.";

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Cliente - " + ex);
                return View();
            }

        }


        public ActionResult Edit(Guid id)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Customer cl = db.Customers.Find(id);
                    return View(cl);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar el cliente - " + ex);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer c)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Customer cl = db.Customers.Find(c.Id);

                    cl.Name = c.Name;
                    cl.DNI = c.DNI;
                    cl.Email = c.Email;
                    cl.Phone = c.Phone;
                    cl.Address = c.Address;

                    db.SaveChanges();

                    ViewBag.Messagecl = "Cliente modificado con éxito.";

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
                Customer cl = db.Customers.Find(id);
                cl.Bank = db.Banks.Find(cl.BankId);

                return View(cl);
            }
        }


        public ActionResult Delete(Guid id)
        {
            using (var db = new EjercMVCDBContext())
            {
                Customer cl = db.Customers.Find(id);
                db.Customers.Remove(cl);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }


        public ActionResult CreateAccount(Guid id)
        {
            return RedirectToAction("CreateFirst", "Account", new { id });
        }
    }
}