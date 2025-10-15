using Source.Domain.Village.Villagers;

namespace Source.Domain.Village.Buildings
{
    public class ResidentialBuildingModel : BuildingBase
    {
        public ResidentialBuildingModel(int capacity) : base(capacity) { }

        protected override void OnSettle(IVillager villager)
        {
            villager.SetProfession(ProfessionType.Resident);
        }
    }
}