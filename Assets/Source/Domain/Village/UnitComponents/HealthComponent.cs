using System;
using Source.Domain.Reactive;
using Source.Domain.Stats;

namespace Source.Domain.Village.UnitComponents
{
    public class HealthComponent : IUnitComponent, IDamageable, IHealable
    {
        private readonly IReadonlyStatAverage _healthStats;
        
        private ReactiveValue<float> _current;

        public HealthComponent(IReadonlyStatsHandler statsHandler)
        {
            _healthStats = statsHandler.GetSafeStatAverage(StatType.MaxHealth);
            _current = new ReactiveValue<float>(_healthStats.Average);
        }

        public IReadonlyReactive<float> Health => _current;
        
        public event Action Died;
        
        public void Heal(float value)
        {
            if(value < 0)
                return;

            _current.Value += value;
            HandleHealth();
        }

        public void Damage(float value)
        {
            if(value < 0)
                return;
            
            _current.Value -= value;
            HandleHealth();
        }

        private void HandleHealth()
        {
            _current.Value = Math.Clamp(_current.Value, 0, _healthStats.Average);
            
            if(_current.Value == 0)
                Died?.Invoke();
        }
    }
}