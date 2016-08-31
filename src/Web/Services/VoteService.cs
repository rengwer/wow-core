using Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IVoteService
    {
        int Count(int petId);
        bool UserHasVoted(int petId, string userName);
    }

    public class VoteService : IVoteService
    {
        private ApplicationDbContext Context { get; set; }
        public VoteService(ApplicationDbContext context)
        {
            Context = context;
        }

        public int Count(int petId)
        {
            return Context.Votes.Count(vote => vote.PetId == petId);
        }

        public bool UserHasVoted(int petId, string userName)
        {
            return Context.Votes.Any(vote => vote.UserName == userName && petId == vote.PetId);
        }
    }
}
