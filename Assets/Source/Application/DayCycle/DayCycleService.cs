using System.Collections.Generic;
using Source.Application.DayCycle.Modules;
using Source.Domain.DayCycle;

namespace Source.Application.DayCycle
{
    public class DayCycleService : IService
    {
        private DayCycleModel _dayCycle;
        private Dictionary<DayTimeType, List<IDayCycleModule>> _modules = new();

        public DayCycleService(DayCycleModel dayCycle, params IDayCycleModule[] modules)
        {
            _dayCycle = dayCycle;

            foreach (IDayCycleModule module in modules)
            {
                if (_modules.TryGetValue(module.Type, out List<IDayCycleModule> cycleModules))
                    cycleModules.Add(module);
                else
                    _modules.Add(module.Type, new List<IDayCycleModule> { module });
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

        private void OnDayTimeChanged(DayTimeType timeType)
        {
            foreach (IDayCycleModule module in _modules[timeType]) 
                module.Handle();
        }

        public void Dispose()
        {
            _dayCycle.Current.Changed -= OnDayTimeChanged;
        }
    }
}