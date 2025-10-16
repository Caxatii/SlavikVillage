using System;
using Source.Application.DataTransfer;
using Source.Domain.Village;
using Source.Domain.Village.Buildings;
using Source.Domain.Village.Villagers;

namespace Source.Application
{
    public class SexService : IService
    {
        private VillageModel _village;

        public SexService(VillageModel village)
        {
            _village = village;
        }

        public event Action<SexPairData> Sexed;
        
        public void Initialize() { }

        public void Handle()
        {
            foreach (BuildingBase building in _village.Buildings)
            {
                SexPairData pairData = new SexPairData();
                
                foreach (IVillager villager in building.Villagers)
                {
                    if(villager.Task.Value != TaskType.Sex)
                        continue;

                    pairData.Set(villager);

                    if (pairData.CanSex())
                    {
                        Sexed?.Invoke(pairData);
                        break;
                    }
                }
            }
        }
        
        public void Dispose() { }
    }
}