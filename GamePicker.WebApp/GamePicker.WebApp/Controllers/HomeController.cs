using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamePicker.WebApp.Models;

namespace GamePicker.WebApp.Controllers
{
    public class HomeController : Controller
    {

        C__USERS_CHRIS_000_DOCUMENTS_SPORTSPICKERDB_MDFContext _myDbContext;

        public HomeController(C__USERS_CHRIS_000_DOCUMENTS_SPORTSPICKERDB_MDFContext context)
        {
            _myDbContext = context;
        }

        public IActionResult Index()
        {
            //Need to figure out what to pass into this controller
            using (var db = _myDbContext)
            {

                var sports = db.Sport.Select(x => x.Team);
                return View(sports);
            } 
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
