using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime DateVoted { get; set; }
        public bool Active { get; set; }
        public int PetId { get; set; }
    }
}
