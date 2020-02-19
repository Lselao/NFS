using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Racing_car.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Racing_car.Controllers
{
    public class HomeController : Controller
    {

        private readonly Db_context _Context;

        public HomeController(Db_context context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            //var sessions = new Sessions() { UserName = "", highScore = 0 };
            return View();
        }

        public IActionResult Leaderboard()
        {
            var leaderboard = _Context.Users.ToList();
            return View(leaderboard);
        }

        //game page method
        public IActionResult Game()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Game([Bind("Name")]Users user)
        {

            if (ModelState.IsValid)
            {
                _Context.Users.Add(user);
                _Context.SaveChanges();
                return RedirectToAction("Game");
            }
            return View("index", user);
            //return View("Game", user);
        }


    }
}
