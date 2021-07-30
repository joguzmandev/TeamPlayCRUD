using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TeamPlayCRUD.Data;
using TeamPlayCRUD.Models;

namespace TeamPlayCRUD.Controllers
{
    public class PlayerController : Controller
    {
        public TeamPlayerContext db { get; set; }
        public PlayerController(TeamPlayerContext context)
        {
            this.db = context;
        }
        public IActionResult Index()
        {
            List<Player> players = db.Players.Include(p => p.Team).Include(p => p.State).ToList();
            return View(players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.teamList = getAllTeamsListItems();
            ViewBag.stateList = getAllStatesListItems();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        [HttpGet]
        public IActionResult EditPlayer(int playerid)
        {
            Player playerFound = db.Players.Include(p => p.Team).Include(p => p.State).Where(p=>p.Id == playerid).FirstOrDefault();

            if (playerFound == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.teamList = getAllTeamsListItems();
            ViewBag.stateList = getAllStatesListItems();

            return View("Create", playerFound);
        }

        [HttpPost]
        public async Task<IActionResult> EditPlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry<Player>(player).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View("Create", player);
        }

        public async Task<IActionResult> DeletePlayer(int playerid)
        {
            Player playerFound = db.Players.Where(p => p.Id == playerid).FirstOrDefault();

            if (playerFound != null)
            {
                db.Entry(playerFound).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
        [Produces("application/json")]
        public async Task<JsonResult> GetPlayersByState(int stateid)
        {
            List<Player> players = await db.Players.Where(p => p.StateId == stateid).ToListAsync();
            return Json(players);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.db = null;
        }

        private List<SelectListItem> getAllTeamsListItems()
        {
            List<SelectListItem> teamsList = (from team in db.Teams
                                              where team.IsActive == true
                                              select new SelectListItem()
                                              {
                                                  Value = team.Id.ToString(),
                                                  Text = team.Name
                                              }).ToList();

            return teamsList;
        }

        private List<SelectListItem> getAllStatesListItems()
        {
            List<SelectListItem> statesList = (from state in db.States
                                               select new SelectListItem()
                                               {
                                                   Value = state.Id.ToString(),
                                                   Text = state.Name
                                               }).ToList();
            return statesList;
        }
    }
}
