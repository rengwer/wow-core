using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Options
{
    public class BattleNetOptions
    { 
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string BaseApiUrl { get; set; }
    }
}
