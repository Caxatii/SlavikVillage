using Source.ContractInterfaces;
using Source.Domain.Village.UnitComponents;

namespace Source.Application.Factories.Components
{
    public interface IUnitComponentFactory
    {
        public IUnitComponent Create(IUnitComponentRepository repository);
    }

    public interface IUnitComponentFactory<T> : IUnitComponentFactory where T : IUnitComponentRepository
    {
        IUnitComponent IUnitComponentFactory.Create(IUnitComponentRepository repository)
        {
            return Create((T)repository);
        }
        
        public IUnitComponent Create(T repository);
    }
}