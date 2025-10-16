using System.Collections.Generic;
using System.Linq;
using Source.Application.DataTransfer;
using Source.Domain.Resources;

namespace Source.Application
{
    public class ResourcesService : IService
    {
        private Dictionary<ResourceType, ResourceModel> _resource;

        public ResourcesService(params ResourceModel[] resource)
        {
            _resource = resource.ToDictionary(k => k.Type, v => v);
        }

        public void Initialize() { }

        public bool IsEnough(IEnumerable<ResourceData> resources)
        {
            foreach (ResourceData data in resources)
            {
                if (IsEnough(data) == false)
                    return false;
            }
            
            return true;
        }

        public bool IsEnough(ResourceData resourceData)
        {
            if (_resource.TryGetValue(resourceData.Type, out ResourceModel resource))
                return resource.IsEnough(resourceData.Value);

            return false;
        }
        
        public bool TrySpend(IEnumerable<ResourceData> resourceData)
        {
            if (IsEnough(resourceData) == false)
                return false;

            foreach (ResourceData data in resourceData) 
                TrySpend(data);
            
            return true;
        }
        
        public bool TrySpend(ResourceData resourceData)
        {
            if (_resource.TryGetValue(resourceData.Type, out ResourceModel resource))
                return resource.TrySpend(resourceData.Value);

            return false;
        }

        public void Increase(ResourceData resourceData)
        {
            if (_resource.TryGetValue(resourceData.Type, out ResourceModel resource)) 
                resource.Increase(resourceData.Value);
            else
                _resource.Add(resourceData.Type, new ResourceModel(resourceData.Value));
        }
        
        public void Dispose() { }
    }
}