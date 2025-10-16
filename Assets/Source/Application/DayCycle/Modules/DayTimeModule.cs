using Source.Domain.DayCycle;
using Source.Domain.Village;
using Source.Domain.Village.Villagers;

namespace Source.Application.DayCycle.Modules
{
    public class DayTimeModule : IDayCycleModule
    {
        private VillageModel _villageModel;

        public DayTimeModule(VillageModel villageModel)
        {
            _villageModel = villageModel;
        }

        public DayTimeType Type => DayTimeType.Day;
        
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
                villager.SetTask(TaskType.Wander);
                return;
            }
            
            villager.SetTask(TaskType.Sleep);
        }
    }
}