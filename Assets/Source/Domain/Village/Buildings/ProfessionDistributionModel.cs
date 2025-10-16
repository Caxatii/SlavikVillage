using Source.Domain.Village.Villagers;

namespace Source.Domain.Village.Buildings
{
    public readonly struct ProfessionDistributionModel
    {
        public readonly ProfessionType Profession;
        public readonly float Chance;

        public ProfessionDistributionModel(ProfessionType profession, float chance)
        {
            Profession = profession;
            Chance = chance;
        }
    }
}