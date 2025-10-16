using Source.Domain.Reactive;
using Source.Domain.Village.Villagers.Tasks;

namespace Source.Domain.Village.Villagers
{
    public interface IVillager
    {
        public IReadonlyReactive<ProfessionType> Profession { get; }
        public IReadonlyReactive<TaskType> Task { get; }
        void SetProfession(ProfessionType profession);
        void SetTask(TaskType task);
    }
}