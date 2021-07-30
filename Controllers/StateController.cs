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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.db = null;
        }
    }
}
