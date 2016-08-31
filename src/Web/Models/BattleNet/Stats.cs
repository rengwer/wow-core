using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.BattleNet
{
    public class Stats
    {
        public int speciesId { get; set; }
        public int breedId { get; set; }
        public int petQualityId { get; set; }
        public int level { get; set; }
        public int health { get; set; }
        public int power { get; set; }
        public int speed { get; set; }
    }
}
