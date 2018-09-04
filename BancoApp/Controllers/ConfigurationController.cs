using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoApp.Controllers
{
    public class ConfigurationController : Controller
    {
        // GET: Configuration
        public ActionResult Index()
        {
            EjercMVCDBContext db = new EjercMVCDBContext();

            return View(db.AccountTypes.ToList());
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountType ac)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    db.AccountTypes.Add(ac);
                    db.SaveChanges();

                    ViewBag.Message = "AccountType agregada con éxito.";

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar AccountType - " + ex);
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    AccountType ac = db.AccountTypes.Find(id);
                    return View(ac);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar AccountType - " + ex);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountType ac)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    AccountType at = db.AccountTypes.Find(ac.Id);

                    at.Name = ac.Name;
                    at.MaxDeposit = ac.MaxDeposit;
                    at.MaxExtracion = ac.MaxExtracion;
                    at.MaxTransfer = ac.MaxTransfer;

                    db.SaveChanges();

                    ViewBag.Message = "AccountType modificado con éxito.";

                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el Banco - " + ex);
                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(Guid id)
        {
            try
            {
                using (var db = new EjercMVCDBContext())
                {
                    AccountType ac = db.AccountTypes.Find(id);
                    return View(ac);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar AccountType - " + ex);
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete(AccountType at)
        {
            using (var db = new EjercMVCDBContext())
            {
                AccountType ac = db.AccountTypes.Find(at.Id);

                //veo que no tenga clientes

                    db.AccountTypes.Remove(ac);
                    db.SaveChanges();
                    ViewBag.Message = "AccountType eliminado con éxito.";
                    return RedirectToAction("Index");

            }
        }



    }
}