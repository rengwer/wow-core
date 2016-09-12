using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.PetViewModels
{
    public class PetDetailViewModel
    {
        
        public int SpeciesId { get; set; }
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public bool CanBattle { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public List<AbilityViewModel> Abilities { get; set; }
        public string Family { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public string StrongAgainst { get; set; }
        public string WeakAgainst { get; set; }
        public bool UserHasVoted { get; set; }
    }
}
