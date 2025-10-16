using ContractInterfaces;
using Source.Domain.Village.Villagers;

namespace Source.Application.Factories.Villagers
{
    public class VillagerFactory : IVillagerFactory
    {
        public IVillager Create(IVillagerRepository repository)
        {
            return new VillagerModel(repository.Stats);
        }
    }
}