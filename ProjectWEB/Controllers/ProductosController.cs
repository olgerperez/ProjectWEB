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
    public class ProductosController : Controller
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

        // GET: Productos
        public ActionResult Index()
        {
            if (session())
            {
                var productos = db.Productos.Include(p => p.Usuario);
                return View(productos.ToList());
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
                
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {

            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Productos productos = db.Productos.Find(id);
                if (productos == null)
                {
                    return HttpNotFound();
                }
                return View(productos); 
            }
            else
            {
                return RedirectToAction("login", "Login");
            }

            
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            if (session())
            {
                ViewBag.usuario_id = new SelectList(db.Usuarios, "id", "nombre_completo");
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
           
        }

        // POST: Productos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,imagen,estado,fecha,usuario_id")] Productos productos)
        {   
            if (ModelState.IsValid)
            {
                productos.fecha = DateTime.Today;
                 
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuario_id = new SelectList(db.Usuarios, "id", "nombre_completo", productos.usuario_id);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Productos productos = db.Productos.Find(id);
                if (productos == null)
                {
                    return HttpNotFound();
                }
                ViewBag.usuario_id = new SelectList(db.Usuarios, "id", "nombre_completo", productos.usuario_id);
                return View(productos);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
            
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,imagen,estado,fecha,usuario_id")] Productos productos)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(productos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.usuario_id = new SelectList(db.Usuarios, "id", "nombre_completo", productos.usuario_id);
                return View(productos);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Productos productos = db.Productos.Find(id);
                if (productos == null)
                {
                    return HttpNotFound();
                }
                return View(productos);
            }
            else
            {
                return RedirectToAction("login", "Login");
            }

        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (session())
            {
                Productos productos = db.Productos.Find(id);
                db.Productos.Remove(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
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
