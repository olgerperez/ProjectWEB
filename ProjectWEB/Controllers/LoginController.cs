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
        public ActionResult Index()
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