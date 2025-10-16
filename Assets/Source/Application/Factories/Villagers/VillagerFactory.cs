using System;
using System.Collections.Generic;
using Source.Application.Factories.Components;
using Source.ContractInterfaces;
using Source.Domain.Village.Villagers;

namespace Source.Application.Factories.Villagers
{
    public class VillagerFactory : IVillagerFactory
    {
        private IUnitComponentFactory _componentFactory;

        public VillagerFactory(IUnitComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }

        public IVillager Create(IVillagerRepository repository)
        {
            VillagerModel villager = new VillagerModel(repository.Stats);
            
            foreach (IUnitComponentRepository component in repository.Components) 
                villager.AddComponent(_componentFactory.Create(component));
            
            return villager;
        }
    }
}