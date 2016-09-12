using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Models.VoteViewModels;

namespace Web.Services
{
    public interface IUserVoteService
    {
        Task<IList<UserVoteViewModel>> GetAsync(string userName);
    }

    public class UserVoteService: IUserVoteService
    {
        private ApplicationDbContext Context { get; set; }
        private IPetService PetService { get; set; }

        public UserVoteService(ApplicationDbContext context, IPetService petService)
        {
            Context = context;
            PetService = petService;
        }

        public async Task<IList<UserVoteViewModel>> GetAsync(string userName)
        {
            var userVotes = new List<UserVoteViewModel>();
            var votes = Context.Votes
                .Where(v => v.UserName == userName)
                .ToList();

            foreach (var vote in votes)
            {
                var pet = await PetService.GetAsync(vote.PetId, userName);

                userVotes.Add(new UserVoteViewModel
                {
                    Icon = pet.Icon,
                    Name = pet.Name
                });
            }

            return userVotes;
        }
    }
}
