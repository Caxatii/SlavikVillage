using Source.Domain.Stats;
using Source.Domain.Village.Villagers;
using UnityEngine;

namespace Source.Domain.Village.Buildings
{
    public class ResidentialBuildingModel : BuildingBase
    {
        public ResidentialBuildingModel(int capacity,
            StatsHandler stats,
            Vector2 worldPosition) : base(capacity,
            stats,
            worldPosition) { }

        protected override void OnSettle(IVillager villager)
        {
            villager.SetProfession(ProfessionType.Resident);
        }
    }
}