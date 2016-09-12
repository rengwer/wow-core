using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.BattleNet
{
    public class Species
    {
        public int speciesId { get; set; }
        public int petTypeId { get; set; }
        public int creatureId { get; set; }
        public string name { get; set; }
        public bool canBattle { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string source { get; set; }
        public List<Ability> abilities { get; set; }
    }

}
