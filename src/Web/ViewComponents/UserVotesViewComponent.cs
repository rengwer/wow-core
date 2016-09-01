using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services;

namespace Web.ViewComponents
{
    public class UserVotesViewComponent : ViewComponent
    {
        private IUserVoteService UserVoteService { get; set; }

        public UserVotesViewComponent(IUserVoteService userVoteService)
        {
            UserVoteService = userVoteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = HttpContext.User.Identity.Name;
            return View(await UserVoteService.GetAsync(userName));
        }
    }
}
