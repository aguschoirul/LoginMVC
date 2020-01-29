using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        public ActionResult Dashboard()
        {
            var list = myContext.Login1.ToList();
            return View(list);
        }


       [HttpPost]
        public ActionResult Masuk(Login login)
        {
            var username = myContext.Login1.Where(a => a.username == login.username).SingleOrDefault();
            if (username != null)
            {
                var password = BCrypt.Net.BCrypt.Verify(login.password, username.password);
                if (password == true)
                {
                    Session["id"] = login.id;
                    Session.Add("username", login.username);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    Session.Add("username", login.username);
                    return View("Welcome");
                }
            }
            else
            {
            }
                ViewBag.error = "Invalid";
                return View("Index");
        }

        // GET: Login
        public ActionResult Index()
        {
            var list = myContext.Login1.ToList();
            return View(list);
        }
        // GET: Login
        public ActionResult Masuk()
        {
            var list = myContext.Login1.ToList();
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View(); 
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Login login)
        {
            try
            {
                // TODO: Add insert logic here
                var mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                login.password = BCrypt.Net.BCrypt.HashPassword(login.password, mySalt);
                myContext.Login1.Add(login);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = myContext.Login1.Find(id);
            return View(edit);
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Login login)
        {
            try
            {
                // TODO: Add update logic here
                var edit = myContext.Login1.Find(id);
                edit.username = login.username;
                edit.password = login.password;
                myContext.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = myContext.Login1.Find(id);
            return View(delete);
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Login login)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = myContext.Login1.Find(id);
                myContext.Login1.Remove(delete);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
