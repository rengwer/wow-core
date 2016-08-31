using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.BattleNet
{
    public class Ability
    {
        public int slot { get; set; }
        public int order { get; set; }
        public int requiredLevel { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int cooldown { get; set; }
        public int rounds { get; set; }
        public int petTypeId { get; set; }
        public bool isPassive { get; set; }
        public bool hideHints { get; set; }
    }
}
