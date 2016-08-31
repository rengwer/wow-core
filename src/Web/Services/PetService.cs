using Web.Models.PetViewModels;
using Web.Services.BattleNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IPetService
    {
        Task<IEnumerable<PetIndexViewModel>> GetAsync();
        Task<PetDetailViewModel> GetAsync(int id, string userName);
    }

    public class PetService : IPetService
    {
        private IBattleNetPetProxy PetProxy { get; set; }
        private IBattleNetSpeciesProxy SpeciesProxy { get; set; }
        private IVoteService VoteService { get; set; }

        public PetService(
            IBattleNetPetProxy petProxy, 
            IBattleNetSpeciesProxy speciesProxy, 
            IVoteService voteService)
        {
            PetProxy = petProxy;
            SpeciesProxy = speciesProxy;
            VoteService = voteService;
        }

        public async Task<IEnumerable<PetIndexViewModel>> GetAsync()
        {
            var pets = await PetProxy.GetAsync();
            return pets
                .Select(pet => new PetIndexViewModel
                    {
                        CreatureId = pet.creatureId,
                        Name = pet.name,
                        Icon = pet.icon,
                        Votes = VoteService.Count(pet.creatureId)
                    })
                .OrderByDescending(pet => pet.Votes);
        }

        public async Task<PetDetailViewModel> GetAsync(int id, string userName)
        {
            var pet = (await PetProxy.GetAsync()).Single(p => p.creatureId == id);
            var species = await SpeciesProxy.GetAsync(pet.stats.speciesId);
            return new PetDetailViewModel
            {
                CreatureId = pet.creatureId,
                CanBattle = pet.canBattle,
                Description = species.description,
                Family = pet.family,
                Health = pet.stats.health,
                Icon = pet.icon,
                Level = pet.stats.level,
                Name = pet.name,
                Power = pet.stats.power,
                Source = species.source,
                SpeciesId = species.speciesId,
                Speed = pet.stats.speed,
                StrongAgainst = String.Join(", ", pet.strongAgainst),
                WeakAgainst = String.Join(", ", pet.weakAgainst),
                UserHasVoted = VoteService.UserHasVoted(pet.creatureId, userName),
                Abilities = species.abilities.Select(a => new AbilityViewModel
                {
                    Cooldown = a.cooldown,
                    Icon = a.icon,
                    Id = a.id,
                    IsPassive = a.isPassive,
                    Name = a.name,
                    Rounds = a.rounds
                }).ToList()
            };

        }
    }
}
