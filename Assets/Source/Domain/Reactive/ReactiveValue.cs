using System;

namespace Domain.Reactive
{
    public class ReactiveValue<T> : IReadonlyReactive<T> where T : struct 
    {
        private T _value;

        public ReactiveValue(T value = default)
        {
            _value = value;
        }
        
        public T Value
        {
            get => _value;
            set
            {
                if(_value.Equals(value))
                    return;

                _value = value;
                Changed?.Invoke(_value);
            }
        }

        public event Action<T> Changed;
    }
}