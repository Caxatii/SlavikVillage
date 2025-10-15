using System.Collections.Generic;
using Source.Domain.Village.Buildings;
using Source.Domain.Village.Villagers;

namespace Source.Domain.Village
{
    public class VillageModel
    {
        private List<IVillager> _villagers = new();
        private List<BuildingBase> _buildings = new();
    }
}