using System.Collections.Generic;
using Source.Domain.Village.Buildings;
using Source.Domain.Village.Villagers;

namespace Source.Domain.Village
{
    public class VillageModel
    {
        private List<IVillager> _villagers = new();
        private List<BuildingBase> _buildings = new();

        public IReadOnlyList<IVillager> Villagers => _villagers;
        public IReadOnlyList<BuildingBase> Buildings => _buildings;

        public void AddVillager(IVillager villager)
        {
            _villagers.Add(villager);
        }

        public void RemoveVillager(IVillager villager)
        {
            _villagers.Remove(villager);
        }

        public void AddBuilding(BuildingBase building)
        {
            _buildings.Add(building);
        }
        
        public void RemoveBuilding(BuildingBase building)
        {
            _buildings.Remove(building);
        }
    }
}