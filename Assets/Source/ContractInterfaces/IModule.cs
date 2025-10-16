using System;

namespace Source.ContractInterfaces
{
    public interface IModule : IDisposable
    {
        public void Initialize();
    }
}