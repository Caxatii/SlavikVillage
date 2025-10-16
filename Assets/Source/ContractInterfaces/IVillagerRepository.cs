using System.Collections.Generic;
using Source.Domain.Stats;

namespace Source.ContractInterfaces
{
    public interface IVillagerRepository
    {
        StatsHandler Stats { get; }
        
        public IReadOnlyList<IUnitComponentRepository> Components { get; }
    }
}