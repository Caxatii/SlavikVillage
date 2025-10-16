using System.Collections.Generic;
using Source.Domain.Stats;
using Source.Domain.Village.Villagers;

namespace Source.Domain.Village.Buildings
{
    public abstract class BuildingBase : Unit
    {
        private List<IVillager> _villagers = new();

        public IReadOnlyList<IVillager> Villagers => _villagers;
        
        protected BuildingBase(int capacity, StatsHandler stats) : base(stats)
        {
            Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public bool IsEnoughCapacity => Capacity > _villagers.Count;
        
        public void Settle(IVillager villager)
        {
            if(IsEnoughCapacity == false)
                return;
                
            OnSettle(villager);
            _villagers.Add(villager);
        }

        public void Evict(IVillager villager)
        {
            if(_villagers.Contains(villager) == false)
                return;
            
            OnEvict(villager);
            _villagers.Remove(villager);
        }
        
        protected abstract void OnSettle(IVillager villager);

        protected virtual void OnEvict(IVillager villager)
        {
            villager.SetProfession(ProfessionType.Homeless);
        }
    }
}