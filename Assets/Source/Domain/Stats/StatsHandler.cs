using System;
using System.Collections.Generic;

namespace The_imp.Mono.Stats
{
    public class StatsHandler : IReadonlyStatsHandler
    {
        private Dictionary<StatType, StatAverage> _statAverages = new();

        public bool Has(Stat stat)
        {
            if(_statAverages.TryGetValue(stat.Type, out var statAverage))
                return statAverage.Has(stat);
            
            return false;
        }

        public bool Has(StatType statType) => 
            _statAverages.ContainsKey(statType);

        public void Add(Stat stat)
        {
            if (_statAverages.ContainsKey(stat.Type) == false) 
                _statAverages.Add(stat.Type, new StatAverage(stat.Type));
            
            _statAverages[stat.Type].Add(stat);
        }

        public float GetAverage(StatType statType)
        {
            if(_statAverages.TryGetValue(statType, out var average) == false)
                return 0;
            
            return average.Average;
        }
        
        public float DisposableAverage(params StatType[] statTypes)
        {
            float average = 0;

            foreach (var statType in statTypes)
                if(_statAverages.TryGetValue(statType, out var statAverage))
                    average += statAverage.CalculateNonMultiplier();
            
            foreach (var statType in statTypes)
                if(_statAverages.TryGetValue(statType, out var statAverage))
                    average *= statAverage.CalculateMultiplier();
            
            return average;
        }
        
        public IReadonlyStatAverage GetSafeStatAverage(StatType statType) => 
            GetStatAverage(statType);

        public StatAverage GetStatAverage(StatType statType)
        {
            if(_statAverages.ContainsKey(statType) == false)
                _statAverages.Add(statType, new StatAverage(statType));
            
            return _statAverages[statType];
        }
        
        public void Remove(Stat stat)
        {
            if(_statAverages.ContainsKey(stat.Type) == false)
                throw new ArgumentException("Cannot remove a non-existing stat");
            
            _statAverages[stat.Type].Remove(stat);
        }

        public void Subscribe(StatType type, Action<float> callback)
        {
            if(_statAverages.ContainsKey(type) == false)
                _statAverages.Add(type, new StatAverage(type));
            
            _statAverages[type].ValueChanged += callback;
        }

        public void Unsubscribe(StatType type, Action<float> callback)
        {
            if(_statAverages.TryGetValue(type, out var statAverage) == false)
                throw new ArgumentException("Cannot unsubscribe a non-existing stat");
            
            statAverage.ValueChanged -= callback;
        }

        public void Merge(StatAverage statAverage)
        {
            if(_statAverages.ContainsKey(statAverage.Type) == false)
                _statAverages.Add(statAverage.Type, new StatAverage(statAverage));
            else
                _statAverages[statAverage.Type].Merge(statAverage);
        }

        public void Merge(StatsHandler statsHandler)
        {
            foreach (StatType type in statsHandler._statAverages.Keys)
            {
                if(_statAverages.ContainsKey(type) == false)
                    _statAverages.Add(type, new StatAverage(statsHandler._statAverages[type]));
                else
                    _statAverages[type].Merge(statsHandler._statAverages[type]);
            }
        }

        public void Discard(StatAverage statAverage)
        {
            if(_statAverages.ContainsKey(statAverage.Type) == false)
                throw new ArgumentException("Cannot discard a non-existing stat");
            
            _statAverages[statAverage.Type].Discard(statAverage);
        }

        public void Discard(StatsHandler statsHandler)
        {
            foreach (StatType type in statsHandler._statAverages.Keys)
            {
                if(_statAverages.ContainsKey(type) == false)
                    throw new ArgumentException("Cannot discard a non-existing StatAverage"); 
                else
                    _statAverages[type].Discard(statsHandler._statAverages[type]);
            }
        }

        public void SafeDiscard(StatAverage statAverage)
        {
            if(_statAverages.ContainsKey(statAverage.Type) == false)
                throw new ArgumentException("Cannot discard a non-existing StatAverage");
            
            _statAverages[statAverage.Type].SafeDiscard(statAverage);
        }

        public void SafeDiscard(StatsHandler statsHandler, bool deepSafe = false)
        {  
            foreach (StatType type in statsHandler._statAverages.Keys)
                if(_statAverages.ContainsKey(type))
                    if(deepSafe)
                        _statAverages[type].SafeDiscard(statsHandler._statAverages[type]);
                    else
                        _statAverages[type].Discard(statsHandler._statAverages[type]);
        }
    }
}