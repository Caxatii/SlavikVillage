using Source.Domain.DayCycle;
using Source.Domain.Village;
using Source.Domain.Village.Villagers;
using Source.Domain.Village.Villagers.Tasks;

namespace Source.Application
{
    public class NightTimeModule : IDayCycleModule
    {
        private VillageModel _villageModel;

        public NightTimeModule(VillageModel villageModel)
        {
            _villageModel = villageModel;
        }

        public DayTimeType Type => DayTimeType.Night;
        
        public void Handle()
        {
            foreach (IVillager villager in _villageModel.Villagers) 
                Handle(villager);
        }

        private void Handle(IVillager villager)
        {
            if (villager.Profession.Value == ProfessionType.Homeless ||
                villager.Profession.Value == ProfessionType.Resident)
            {
                villager.SetTask(TaskType.Sleep);
                return;
            }
            
            villager.SetTask(TaskType.Wander);
        }
    }
}