
using Source.Domain.Reactive;

namespace Source.Domain.Resources
{
    public class ResourceModel
    {
        private ReactiveValue<int> _value;

        public ResourceModel(int value = 0)
        {
            _value = new ReactiveValue<int>(value);
        }
        
        public ResourceType Type { get; }
        public IReadonlyReactive<int> Value => _value;

        public bool IsEnough(int value) => _value.Value >= value;

        public bool TrySpend(int value)
        {
            if (value < 0)
                return false;
            
            bool isEnough = IsEnough(value);

            if (isEnough)
                _value.Value -= value;
            
            return isEnough;
        }

        public void Increase(int value)
        {
            if (value < 0)
                return;

            _value.Value += value;
        }
    }
}