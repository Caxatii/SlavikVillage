using Source.Domain.Stats;
using Source.Domain.Village.Villagers;

namespace Source.Domain.Village.Buildings
{
    public class ResidentialBuildingModel : BuildingBase
    {
        public ResidentialBuildingModel(int capacity, StatsHandler stats) : base(capacity, stats) { }

        protected override void OnSettle(IVillager villager)
        {
            villager.SetProfession(ProfessionType.Resident);
        }
    }
}