using Source.Domain.Stats;
using Source.Domain.Village.Villagers;
using UnityEngine;
using Random = System.Random;

namespace Source.Domain.Village.Buildings
{
    public class TowerBuildingModel : BuildingBase
    {
        private Random _random = new();

        public TowerBuildingModel(int capacity,
            StatsHandler stats,
            Vector2 worldPosition) : base(capacity,
            stats,
            worldPosition) { }

        protected override void OnSettle(IVillager villager)
        {
            ProfessionType type = (ProfessionType)_random.Next(2, 5);
            villager.SetProfession(type);
        }
    }
}