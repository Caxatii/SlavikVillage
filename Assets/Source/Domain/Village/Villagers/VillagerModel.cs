using Source.Domain.Reactive;
using Source.Domain.Stats;
using Source.Domain.Village.Villagers.Tasks;

namespace Source.Domain.Village.Villagers
{
    public class VillagerModel : Unit, IVillager
    {
        private ReactiveValue<TaskType> _task;
        private ReactiveValue<ProfessionType> _profession;

        public IReadonlyReactive<ProfessionType> Profession => _profession;
        public IReadonlyReactive<TaskType> Task => _task;
        
        public VillagerModel(StatsHandler stats) : base(stats) { }

        public void SetProfession(ProfessionType profession) => 
            _profession.Value = profession;

        public void SetTask(TaskType task) => 
            _task.Value = task;
    }
}