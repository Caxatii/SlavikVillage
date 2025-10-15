using System;
using Source.Domain.Stats;
using Source.Domain.Village.Villagers;

namespace Source.Domain.Village.Buildings
{
    public class TowerBuildingModel : BuildingBase
    {
        private Random _random = new();
        
        public TowerBuildingModel(int capacity, StatsHandler stats) : base(capacity, stats) { }

        protected override void OnSettle(IVillager villager)
        {
            ProfessionType type = (ProfessionType)_random.Next(2, 5);
            villager.SetProfession(type);
        }
    }
}