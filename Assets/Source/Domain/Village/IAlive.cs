using System;
using Source.Domain.Reactive;

namespace Source.Domain.Village
{
    public interface IAlive
    {
        public IReadonlyReactive<float> Health { get; }

        public event Action Died;
    }
}