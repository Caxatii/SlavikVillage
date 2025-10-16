using System;
using System.Collections.Generic;
using ContractInterfaces;
using Source.Domain.Village.Buildings;

namespace Source.Application.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        private Dictionary<Type, IBuildingFactory> _factories = new();

        public void Add<T>(IBuildingFactory factory) where T : IBuildingRepository
        {
            _factories.Add(typeof(T), factory);
        }
        
        public BuildingBase Create(IBuildingRepository repository)
        {
            return _factories[repository.GetType()].Create(repository);
        }
    }
}