using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamPlayCRUD.Data;
using TeamPlayCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamPlayCRUD.Controllers
{
    public class TeamController : Controller
    {
        public TeamPlayerContext db { get; set; }

        public TeamController(TeamPlayerContext context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            List<Team> teams = db.Teams.ToList();
            return View(teams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.stateListItems = getAllState();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.stateListItems = getAllState();
            return View(team);
        }

        [HttpGet]
        public IActionResult EditTeam(int teamid)
        {
            Team teamFound = db.Teams.Where(team => team.Id == teamid).FirstOrDefault();

            if(teamFound == null)
            {
                return RedirectToAction("Index");
            }

            return View("Create",teamFound);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry<Team>(team).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View("Create", team);
        }

        public async Task<IActionResult> DeleteTeam(int teamid)
        {
            Team teamFound = db.Teams.Where(team => team.Id == teamid).FirstOrDefault();

            if (teamFound != null)
            {
                db.Entry(teamFound).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DisplayAllPlayer(int teamid)
        {
            Team team = await db.Teams.Include(p => p.Players).Where(t => t.Id == teamid).FirstOrDefaultAsync();
            if(team == null)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.db = null;
        }

        private List<SelectListItem> getAllState()
        {
            var selectListItemsStates = from state in db.States
                                        select new SelectListItem()
                                        {
                                            Text = state.Name,
                                            Value = state.Id.ToString()
                                        };

           return selectListItemsStates.ToList();
        }
    }
}
