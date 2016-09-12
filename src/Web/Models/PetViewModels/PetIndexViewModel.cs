using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.PetViewModels
{
    public class PetIndexViewModel
    {
        public int CreatureId { get; set; }
        public string Name {get; set;}
        public string Icon { get; set; }
        public int Votes { get; set; }
    }
}
