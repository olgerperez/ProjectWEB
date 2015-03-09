using ProjectWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectWEB.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationContext dbContext = new ApplicationContext();

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


        // GET: Login

        [HttpGet]
        public ActionResult login()
        {
            if (session())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
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
                dbContext.Usuarios.Add(usuarios);
                dbContext.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(usuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login([Bind(Include = "usuario,contrasena")] Usuarios usuario)
        {
            var user = Request["usuario"];
            var contra = Request["contrasena"];
            if (IsValid(Request["usuario"], Request["contrasena"]))
            {
                Response.Cookies["authentication"].Value = user;

                Response.Cookies["authentication"].Expires = DateTime.Now.AddDays(1);

                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Usuario Incorrecto");
            }

            return View(usuario);
        }

        private bool IsValid(string user, string password)
        {
            bool isValid = false;
            {
                var usuario = dbContext.Usuarios.FirstOrDefault(u => u.usuario == user);

                if (usuario != null)
                {
                    var encrpPass = Crypto.Hash(password);
                    if (usuario.contrasena == encrpPass)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

    }
}