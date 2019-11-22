using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transformer.Models;

namespace Transformer.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection user)
        {
            return RedirectToAction("Index");
        }
        public ActionResult Admin()
        {

            BalUser bal = new BalUser();

            return View(bal.List());
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection user)
        {

            BalUser bal = new BalUser();
            bal.Is_Active = true;
            bal.Year = DateTime.Now.Year.ToString();
            bal.Name = user["Name"];
            bal.Phone = user["Phone"];
            bal.Address = user["Address"];
            bal.Username = user["Username"];
            bal.Password = user["Password"];
            bal.Email = user["Email"];
            bal.Insert(bal);
            return RedirectToAction("Admin");
        }

        public ActionResult Delete(int id)
        {

            BalUser bal = new BalUser();
            bal.Delete(id);
            return View();
        }

        public ActionResult Subscribe(int id)
        {

            BalUser bal = new BalUser();
            bal.Delete(id);
            return View();
        }

        public ActionResult Try()
            {
            return View();
            }

        [HttpPost]
        public ActionResult Try(FormCollection user)
        {
            return View();
        }

    }
}