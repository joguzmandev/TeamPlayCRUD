using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamPlayCRUD.Data;
using TeamPlayCRUD.Models;

namespace TeamPlayCRUD.Controllers
{
    public class StateController : Controller
    {
        public TeamPlayerContext db { get; set; }
        public StateController(TeamPlayerContext context)
        {
            this.db = context;
        }
        public IActionResult Index()
        {
            List<State> states = db.States.ToList();
            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(State state)
        {
            state.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.States.Add(state);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(state);
        }


        [Produces("application/json")]
        public JsonResult GetAllStates()
        {
            List<State> states = db.States.ToList();
            return Json(states);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.db = null;
        }
    }
}
