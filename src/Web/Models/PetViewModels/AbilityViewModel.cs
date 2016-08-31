using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.PetViewModels
{
    public class AbilityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Cooldown { get; set; }
        public int Rounds { get; set; }
        public bool IsPassive { get; set; }
    }
}
