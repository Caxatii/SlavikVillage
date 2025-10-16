using System.Collections.Generic;
using Source.Domain.Reactive;

namespace Source.Domain.DayCycle
{
    public class DayCycleModel
    {
        private float _time;
        private float _maxTime;

        private ReactiveValue<DayTimeType> _current;
        
        private Dictionary<DayTimeType, TimePeriod> _periods = new ();

        public float CyclePercent => _time / _maxTime;

        public IReadonlyReactive<DayTimeType> Current => _current;

        public DayCycleModel(params TimePeriod[] periods)
        {
            _current = new (periods[0].Current);
            
            foreach (TimePeriod period in periods)
            {
                _periods.Add(period.Current, period);
                _maxTime += period.Time;
            }
        }
        
        public void AddTime(float time)
        {
            _time += time;

            if (_time >= _periods[_current.Value].Time)
                SetNextTime();
        }

        private void SetNextTime()
        {
            TimePeriod currentPeriod = _periods[_current.Value];
            DayTimeType nextPeriod = currentPeriod.Next;

            _time -= currentPeriod.Time;
            _current.Value = _periods[nextPeriod].Current;
        }
    }
}