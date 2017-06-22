using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamePicker.WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamePicker.WebApp.Controllers
{
    public class GamesContoller : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Game game = new Game();

            

            return View();
        }
    }
}
