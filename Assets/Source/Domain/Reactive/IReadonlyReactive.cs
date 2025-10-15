using System;

namespace Domain.Reactive
{
    public interface IReadonlyReactive<out T> where T : struct
    {
        public T Value {get;}

        public event Action<T> Changed;
    }
}