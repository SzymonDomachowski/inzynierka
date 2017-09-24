using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotificationBox.Domain.Entities;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using NotificationBox.Domain.Abstract;
using NotificationBox.Domain.Concrete;
using NotificationBox.WebUI.Models;

namespace NotificationBox.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repository;

        public HomeController(IUserRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult UserList()
        {
            return View(repository.Users);
        }

        public ViewResult Account()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Account(User user)
        {
            if (ModelState.IsValid)
            {
                repository.AddAccount(user);
                TempData["message"] = string.Format("Zapisano {0}", user.Login);
                return RedirectToAction("Decision",new { Id = user.UserID});
            }
            else
            {
                return View(user);
            }
        }

        public ViewResult Decision(int Id)
        {
            InstagramApp.TempId = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Login,string Password)
        {
            User user = repository.Users.FirstOrDefault(u => u.Login == Login && u.Password == Password);

            if(user == null)
            {
                TempData["message"] = string.Format("Podano zly login lub haslo");             
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = string.Format("Zalogowano");
                return RedirectToAction("Decision",new {id = user.UserID });
            }
            
        }
    }
}