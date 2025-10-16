using System.Collections.Generic;
using Source.Domain.Stats;
using Source.Domain.Village.UnitComponents;

namespace Source.Domain.Village
{
    public class Unit
    {
        private StatsHandler _stats;
        private List<IUnitComponent> _components = new();

        public Unit(StatsHandler stats)
        {
            _stats = stats;
        }

        public void AddComponent(IUnitComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(IUnitComponent component)
        {
            _components.Remove(component);
        }
        
        public IReadonlyStatsHandler Stats => _stats;

        public IReadOnlyList<IUnitComponent> Components => _components;
    }
}