using Web.Models.BattleNet;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Options;
using Microsoft.Extensions.Options;

namespace Web.Services.BattleNet
{
    public interface IBattleNetSpeciesProxy
    {
        Task<Species> GetAsync(int id);
    }

    public class BattleNetSpeciesProxy : BaseBattleNetProxy<Species>, IBattleNetSpeciesProxy
    {
        private List<Species> SpeciesCache { get; set; }

        public BattleNetSpeciesProxy(IOptions<BattleNetOptions> battleNetOptions) : base(battleNetOptions)
        {
            SpeciesCache = new List<Species>();
        }

        public async Task<Species> GetAsync(int id)
        {
            return await GetInternalAsync (id);
        }

        private async Task<Species> GetInternalAsync(int id)
        {
            if (!SpeciesCache.Any(species => species.speciesId == id))
            {
                var species = await Get($"pet/species/{id}");
                SpeciesCache.Add(species);
                return species;
            }

            return SpeciesCache.Single(species => species.speciesId == id);
        }
    }
}
