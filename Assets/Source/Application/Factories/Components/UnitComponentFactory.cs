using System;
using System.Collections.Generic;
using Source.ContractInterfaces;
using Source.Domain.Village.UnitComponents;

namespace Source.Application.Factories.Components
{
    public class UnitComponentFactory : IUnitComponentFactory
    {
        private Dictionary<Type, IUnitComponentFactory> _factories = new();

        public void Add<T>(IUnitComponentFactory<T> factory) where T : IUnitComponentRepository
        {
            _factories.Add(typeof(T), factory);
        }
        
        public IUnitComponent Create(IUnitComponentRepository repository)
        {
            return _factories[repository.GetType()].Create(repository);
        }
    }
}