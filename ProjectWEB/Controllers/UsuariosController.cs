using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectWEB.Models;
using System.Web.Helpers;

namespace ProjectWEB.Controllers
{
    public class UsuariosController : Controller
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
        // GET: Usuarios
        public ActionResult Index()
        {
            if (session())
            {
                return View(db.Usuarios.ToList());
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }       
        }

        // GET: Usuarios/Create
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

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre_completo,usuario,contrasena,correo,telefono")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.contrasena = Crypto.Hash(usuarios.contrasena);
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(usuarios);
        }
        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
            
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre_completo,usuario,contrasena,correo,telefono")] Usuarios usuarios)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
           
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
           
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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
