using Web.Models.BattleNet;
using Web.Models.Options;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Services.BattleNet
{
    public interface IBattleNetPetProxy
    {
        Task<IEnumerable<Pet>> GetAsync();
    }

    public class BattleNetPetProxy : BaseBattleNetProxy<Pets>, IBattleNetPetProxy
    {
        private Pets PetsCache { get; set; }

        public BattleNetPetProxy(IOptions<BattleNetOptions> battleNetOptions) : base(battleNetOptions)
        {
            PetsCache = new Pets { pets = new List<Pet>() };
        }

        public async Task<IEnumerable<Pet>> GetAsync()
        {
            return (await GetInternalAsync()).pets;
        }

        private async Task<Pets> GetInternalAsync()
        {
            if (PetsCache.pets.Count == 0)
                PetsCache = await Get("pet/");

            return PetsCache;
        }
    }
}
