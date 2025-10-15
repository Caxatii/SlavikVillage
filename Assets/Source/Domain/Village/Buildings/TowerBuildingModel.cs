using Source.Domain.Village.Villagers;

namespace Source.Domain.Village.Buildings
{
    public class TowerBuildingModel : BuildingBase
    {
        
        
        public TowerBuildingModel(int capacity) : base(capacity)
        {
        }

        protected override void OnSettle(IVillager villager)
        {
            
        }
    }
}