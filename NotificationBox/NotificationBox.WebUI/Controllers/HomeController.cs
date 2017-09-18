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


    }
}