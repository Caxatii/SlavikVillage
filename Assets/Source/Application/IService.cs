using System;

namespace Source.Application
{
    public interface IService : IDisposable
    {
        public void Initialize();
    }
}