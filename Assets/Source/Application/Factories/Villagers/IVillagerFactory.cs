using ContractInterfaces;
using Source.Domain.Village.Villagers;

namespace Source.Application.Factories.Villagers
{
    public interface IVillagerFactory
    {
        public IVillager Create(IVillagerRepository repository);
    }
}