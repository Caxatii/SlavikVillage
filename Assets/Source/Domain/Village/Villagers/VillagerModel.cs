using Source.Domain.Reactive;
using Source.Domain.Stats;

namespace Source.Domain.Village.Villagers
{
    public class VillagerModel : Unit, IVillager
    {
        private ReactiveValue<ProfessionType> _profession;

        public IReadonlyReactive<ProfessionType> Profession => _profession;
        
        public VillagerModel(StatsHandler stats) : base(stats) { }

        public void SetProfession(ProfessionType profession)
        {
            _profession.Value = profession;
        }
    }
}