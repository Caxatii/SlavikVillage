using ContractInterfaces;
using Source.Domain.Village.Buildings;

namespace Source.Application.Factories
{
    public interface IBuildingFactory
    {
        public BuildingBase Create(IBuildingRepository repository); 
    }

    public interface IBuildingFactory<T> : IBuildingFactory where T : IBuildingRepository
    {
        BuildingBase IBuildingFactory.Create(IBuildingRepository repository)
        {
            return Create((T)repository);
        }
        
        public BuildingBase Create<T>(T repository);
    }
}