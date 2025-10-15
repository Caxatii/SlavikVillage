using Source.Domain.Village.Villagers.Tasks;

namespace Source.Domain.Village.Villagers
{
    public interface IVillager
    {
        void SetProfession(ProfessionType profession);
        void SetTask(TaskType task);
    }
}