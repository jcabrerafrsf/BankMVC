using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Entities;

namespace BancoApp.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {
            EjercMVCDBContext db = new EjercMVCDBContext();

            return View(db.Banks.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bank b)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new EjercMVCDBContext())
                {

                    db.Banks.Add(b);
                    db.SaveChanges();

                    ViewBag.Message = "Banco agregado con éxito.";

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Banco - " + ex);
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Bank bn = db.Banks.Find(id);
                    return View(bn);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Banco - " + ex);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bank b)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Bank bn = db.Banks.Find(b.Id);

                    bn.Name = b.Name;

                    db.SaveChanges();

                    ViewBag.Message = "Banco modificado con éxito.";

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Banco - " + ex);
                return RedirectToAction("Index");
            }
        }


        public ActionResult Details(Guid id)
        {
            using (var db = new EjercMVCDBContext())
            {
                Bank bn = db.Banks.Find(id);

                return View(bn);
            }
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    Bank bn = db.Banks.Find(id);
                    if(bn.Customers.Count != 0)
                    {
                        ViewBag.Message = "Contains customers.";
                    }
                    else
                    {
                        ViewBag.Message = null;
                    }

                    return View(bn);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Banco - " + ex);
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete(Bank b)
        {
            using (var db = new EjercMVCDBContext())
            {
                Bank bn = db.Banks.Find(b.Id);

                //veo que no tenga clientes

                if (db.Banks.Find(b.Id).Customers.Count() == 0)
                {
                    db.Banks.Remove(bn);
                    db.SaveChanges();
                    ViewBag.Message = "Banco eliminado con éxito.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "No es posible eliminar el banco ya que contiene clientes.";

                    return RedirectToAction("Index");
                }
            }
        }


        public ActionResult CreateCustomer(Guid id)
        {
            return RedirectToAction("Create", "Customer", new { id });
        }
    }
}