using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectWEB.Models;

namespace ProjectWEB.Controllers
{
    public class TransaccionesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        public Boolean session()
        {
            if (Request.Cookies["authentication"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: Transacciones
        public ActionResult Index()
        {
            if (session())
            {
                return View(db.Transacciones.ToList());
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
            
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transacciones transacciones = db.Transacciones.Find(id);
                if (transacciones == null)
                {
                    return HttpNotFound();
                }
                return View(transacciones);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
                       
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            if (session())
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
            
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,producto_ofrecido,producto_interes,fecha,estado")] Transacciones transacciones)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {
                    db.Transacciones.Add(transacciones);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(transacciones);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
           
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transacciones transacciones = db.Transacciones.Find(id);
                if (transacciones == null)
                {
                    return HttpNotFound();
                }
                return View(transacciones);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
            
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,producto_ofrecido,producto_interes,fecha,estado")] Transacciones transacciones)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transacciones).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(transacciones);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
            
        }

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transacciones transacciones = db.Transacciones.Find(id);
                if (transacciones == null)
                {
                    return HttpNotFound();
                }
                return View(transacciones);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
           
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacciones transacciones = db.Transacciones.Find(id);
            db.Transacciones.Remove(transacciones);
            db.SaveChanges();
            return RedirectToAction("Index");
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
