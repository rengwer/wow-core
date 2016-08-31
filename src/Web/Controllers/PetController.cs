using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Web.Services;
using Web.Data;
using Web.Models;
using System;

namespace Web.Controllers
{
    [Authorize()]
    public class PetController : Controller
    {
        private IPetService PetService { get; set; }
        private ApplicationDbContext Context { get; set; }
     
        public PetController(IPetService petService, ApplicationDbContext context)
        {
            PetService = petService;
            Context = context;
        }

        // GET: Pet
        public async Task<ActionResult> Index()
        {
            return View(await PetService.GetAsync());
        }

        // Detail: Pet
        public async Task<ActionResult> Detail(int id)
        {
            return View(await PetService.GetAsync(id, HttpContext.User.Identity.Name));
        }

        [HttpPost]
        public async Task<ActionResult> Vote(int id)
        {
            var vote = new Vote
            {
                UserName = HttpContext.User.Identity.Name,
                DateVoted = DateTime.Now,
                Active = true,
                PetId = id,
            };

            Context.Votes.Add(vote);
            await Context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}