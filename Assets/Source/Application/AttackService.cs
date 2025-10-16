using Source.Domain.Village;

namespace Source.Application
{
    public class AttackService : IService
    {
        private VillageModel _villageModel;

        public AttackService(VillageModel villageModel)
        {
            _villageModel = villageModel;
        }

        public void Initialize() { }

        public void Handle()
        {
            
        }

        public void Dispose() { }
    }
}