using System;
using System.Collections.Generic;
using Source.ContractInterfaces;
using Source.Domain.Village.Buildings;

namespace Source.Application.Factories.Buildings
{
    public class BuildingFactory : IBuildingFactory
    {
        private Dictionary<Type, IBuildingFactory> _factories = new();

        public void Add<T>(IBuildingFactory<T> factory) where T : IBuildingRepository
        {
            _factories.Add(typeof(T), factory);
        }
        
        public BuildingBase Create(IBuildingRepository repository)
        {
            return _factories[repository.GetType()].Create(repository);
        }
    }
}