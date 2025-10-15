using System.Collections.Generic;
using Source.Domain.DayCycle;

namespace Source.Application
{
    public class DayCycleService : IService
    {
        private DayCycleModel _dayCycle;
        private Dictionary<DayTimeType, IDayCycleModule> _modules;

        public DayCycleService(DayCycleModel dayCycle, params IDayCycleModule[] modules)
        {
            _dayCycle = dayCycle;

            foreach (IDayCycleModule module in modules)
            {
                
            }
        }

        public void Initialize()
        {
            _dayCycle.Current.Changed += OnDayTimeChanged;
        }

        public void AddTime(float time)
        {
            _dayCycle.AddTime(time);
        }

        private void OnDayTimeChanged(DayTimeType obj)
        {
            
        }

        public void Dispose()
        {
            _dayCycle.Current.Changed -= OnDayTimeChanged;
        }
    }
}