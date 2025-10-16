using Source.Domain.Stats;

namespace ContractInterfaces
{
    public interface IVillagerRepository
    {
        StatsHandler Stats { get; }
    }
}