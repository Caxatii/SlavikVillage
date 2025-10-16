using Source.Application;
using Source.ContractInterfaces.Application;
using Source.Domain.Village.Villagers;

namespace Source.ContractInterfaces
{
    public interface ITaskService : IService
    {
        public ITaskAction GetAction(IVillager villager);
    }
}