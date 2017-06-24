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

                var sports = db.Sport.ToList();
                return View(sports);
            }           
        }
        public IActionResult Games()
        {
            using (var db = _myDbContext)
            {
                var todayGame = db.Game.Where(x => x.GameDateTime.Date == DateTime.Today.Date)
                    .GroupBy(x => new { x.HomeTeamId, x.GameDateTime, x.AwayTeamId }) 
                    .Select(group => group.First())
                    .ToList();

                var gamesToDisplay = todayGame.Select(x => new GamesDisplayInfo()
                {
                    GameTime = x.GameDateTime,
                    AwayTeam = GetTeamInfo(db, x.AwayTeamId),
                    AwayTeamId = x.AwayTeamId,
                    HomeTeam = GetTeamInfo(db, x.HomeTeamId),
                    HomeTeamId = x.HomeTeamId
                })
                .OrderBy(y => y.GameTime)
                .ToList();

                return View(gamesToDisplay);
            }
        }

        private string GetTeamInfo( C__USERS_CHRIS_000_DOCUMENTS_SPORTSPICKERDB_MDFContext db, int id)
        {     
                var team = db.Team.Where(x => x.TeamId == id).FirstOrDefault();
                return $"{team.TeamLocation} {team.TeamName}";            
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
