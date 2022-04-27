using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
              //1. ...all womens' leagues
            ViewBag.WomensLeagues = _context.Leagues
                .Where( w => w.Name.Contains("Women"))
                .ToList();

            //2....all leagues where sport is any type of hockey
            ViewBag.HockeyTeams = _context.Leagues
                .Where( w => w.Sport.Contains("Hockey"))
                .ToList();

            //3....all leagues where sport is something OTHER THAN football
            ViewBag.NotTheFootball = _context.Leagues
                .Where( w => w.Sport!="Football")
                .ToList();

            //4....all leagues that call themselves "conferences"
            ViewBag.Conferences = _context.Leagues
                .Where(c => c.Name.Contains("Conference"))
                .ToList();

            //5....all leagues in the Atlantic region
            ViewBag.AtlanticTeams = _context.Leagues
                .Where(a => a.Name.Contains("Atlantic"));

            //6....all teams based in Dallas
            ViewBag.DallasTeams = _context.Teams
                .Where( t => t.Location == "Dallas")
                .ToList();

            //7....all teams named the Raptors
            ViewBag.Raptors = _context.Teams
                .Where(r => r.TeamName == "Raptors");

            //8....all teams whose location includes "City"
            ViewBag.CityTeams = _context.Teams
                .Where(c => c.Location.Contains("City"));

            //9....all teams whose names begin with "T"
            ViewBag.StartsT = _context.Teams
                .Where(t => t.TeamName.StartsWith("T"))
                .ToList();

            //10....all teams, ordered alphabetically by location
            ViewBag.AlphaLoc = _context.Teams
                .OrderBy(l => l.Location)
                .ToList();

            //11....all teams, ordered by team name in reverse alphabetical order
            ViewBag.ReverseTeams = _context.Teams
                .OrderByDescending( t => t.TeamName )
                .ToList();

            //12....every player with last name "Cooper"
            ViewBag.Cooper = _context.Players
                .Where(p => p.LastName == "Cooper")
                .ToList();

            //13....every player with first name "Joshua"
            ViewBag.Joshua = _context.Players
                .Where(p => p.FirstName == "Joshua")
                .ToList();

            //14....every player with last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.CooperNoJosh = _context.Players
                .Where(p => p.LastName == "Cooper")
                .Where(p => p.FirstName != "Joshua")
                .ToList();

            //15....all players with first name "Alexander" OR first name "Wyatt"
            ViewBag.AlexWyatt = _context.Players
                .Where(p => p.FirstName == "Alexander" || p.FirstName == "Wyatt")
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}