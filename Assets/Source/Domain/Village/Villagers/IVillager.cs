using Source.Domain.Reactive;

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