using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.BattleNet
{
    public class Pet
    {
        public bool canBattle { get; set; }
        public int creatureId { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string icon { get; set; }
        public int qualityId { get; set; }
        public Stats stats { get; set; }
        public List<string> strongAgainst { get; set; }
        public int typeId { get; set; }
        public List<string> weakAgainst { get; set; }
    }
}
