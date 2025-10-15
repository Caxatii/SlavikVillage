using System;
using Source.Domain.Reactive;
using Source.Domain.Stats;

namespace Source.Domain.Village
{
    public class Unit : IDamageable, IHealable
    {
        private ReactiveValue<float> _health;
        private StatAverage _healthStat;
        private StatsHandler _stats;

        public Unit(StatsHandler stats)
        {
            _stats = stats;
            _healthStat = _stats.GetStatAverage(StatType.MaxHealth);
        }

        public IReadonlyReactive<float> Health => _health;

        public IReadonlyStatsHandler Stats => _stats;
        
        public IReadonlyStatAverage HealthAverage => _healthStat;

        public event Action Died;

        
        
        public void Heal(float value)
        {
            if(value < 0)
                return;

            _health.Value += value;
            HandleHealth();
        }

        public void Damage(float value)
        {
            if(value < 0)
                return;
            
            _health.Value -= value;
            HandleHealth();
        }
        
        private void HandleHealth()
        {
            _health.Value = Math.Clamp(_health.Value, 0, _healthStat.Average);
            
            if(_health.Value == 0)
                Died?.Invoke();
        }
    }
}