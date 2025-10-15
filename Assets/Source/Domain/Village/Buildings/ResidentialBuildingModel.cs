namespace Domain.Source.Domain.Villagers
{
    public class ResidentialBuildingModel : BuildingBase
    {
        public int ResidentsCount { get; private set; }
        public int Capacity { get; private set; }

        //settle, evict
        public void Settle(Villager villager)
        {
            if()
        }
    }
}