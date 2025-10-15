using System;
using System.Collections.Generic;
using System.Linq;

namespace Source.Domain.Stats
{
    public class StatAverage : IReadonlyStatAverage, IDisposable
    {
        private List<Stat> _nonMultiplierStats;
        private List<Stat> _multiplierStats;
        
        public StatAverage(StatType type)
        {
            _nonMultiplierStats = new List<Stat>();
            _multiplierStats = new List<Stat>();
            
            Type = type;
        }

        public StatAverage(StatAverage statAverage)
        {
            _multiplierStats = new List<Stat>(statAverage._multiplierStats);
            _nonMultiplierStats = new List<Stat>(statAverage._nonMultiplierStats);
            
            Type = statAverage.Type;
            UpdateAverage();
        }

        public StatAverage(IEnumerable<Stat> stats)
        {
            Type = stats.First().Type;
            
            if(stats.Any(s => s.Type != Type))
                throw new ArgumentException("Wrong type in params");
            
            _multiplierStats = stats.Where(s => s.IsMultiplier).ToList();
            _nonMultiplierStats = stats.Where(s => s.IsMultiplier == false).ToList();
            
            UpdateAverage();
        }

        public StatType Type { get; }
        
        public float Average { get; private set; }

        public event Action<float> ValueChanged;

        public bool Has(Stat stat)
        {
            IsEqual(stat);
            
            bool result = _nonMultiplierStats.Contains(stat);
            bool result2 = _multiplierStats.Contains(stat);
            
            return result || result2;
        }
        
        public void Add(Stat stat)
        {
            IsEqual(stat);
            
            if(stat.IsMultiplier)
                _multiplierStats.Add(stat);
            else
                _nonMultiplierStats.Add(stat);

            UpdateAverage();
        }

        public void Remove(Stat stat)
        {
            IsEqual(stat);

            bool contains = _nonMultiplierStats.Contains(stat);
            bool contains2 = _multiplierStats.Contains(stat);
            
            if(contains)
                _nonMultiplierStats.Remove(stat);

            if(contains2)
                _multiplierStats.Remove(stat);
            
            if(contains || contains2)
                UpdateAverage();
            else
                throw new ArgumentException("Cannot remove a non-existing stat");
        }

        public float DisposableAverage(StatAverage statAverage)
        {
            float result = CalculateNonMultiplier();
            result += statAverage.CalculateNonMultiplier();
            
            result *= CalculateMultiplier();
            result *= statAverage.CalculateMultiplier();
            
            return result;
        }
        
        public void Merge(StatAverage statAverage)
        {
            IsEqual(statAverage);
            
            _multiplierStats.AddRange(new List<Stat>(statAverage._multiplierStats));
            _nonMultiplierStats.AddRange(new List<Stat>(statAverage._nonMultiplierStats));
            
            UpdateAverage();
        }

        public void Discard(StatAverage statAverage)
        {
            IsEqual(statAverage);
            
            foreach (Stat stat in statAverage._multiplierStats)
            {
                if (_multiplierStats.Contains(stat) == false)
                    ThrowWrongDiscard();
                
                _multiplierStats.Remove(stat);
            }
            
            foreach (Stat stat in statAverage._nonMultiplierStats)
            {
                if (_nonMultiplierStats.Contains(stat) == false)
                    ThrowWrongDiscard();
                
                _nonMultiplierStats.Remove(stat);
            }
            
            UpdateAverage();
        }

        public void SafeDiscard(StatAverage statAverage)
        {
            IsEqual(statAverage);

            foreach (Stat stat in statAverage._multiplierStats)
                if (_multiplierStats.Contains(stat))
                    _multiplierStats.Remove(stat);
            
            foreach (Stat stat in statAverage._nonMultiplierStats)
                if (_nonMultiplierStats.Contains(stat))
                    _multiplierStats.Remove(stat);
            
            UpdateAverage();
        }

        public float CalculateNonMultiplier()
        {
            float average = 0;
            
            foreach(var stat in _nonMultiplierStats)
                average += stat.Value;
            
            return average;
        }

        public float CalculateMultiplier()
        {
            float average = 1;
            
            foreach(var stat in _multiplierStats)
                average *= stat.Value;
            
            return average;
        }

        private float CalculateAverage()
        {
            float average = CalculateNonMultiplier();
            average *= CalculateMultiplier();
            
            return average;
        }

        private void UpdateAverage()
        {
            var average = CalculateAverage();

            if (average != Average)
            {
                Average = average;
                ValueChanged?.Invoke(average);
            }
            
            Average = average;
        }

        private void ThrowWrongDiscard() =>
            throw new Exception("Wrong discard operation");
        
        private void IsEqual(StatAverage statAverage)
        {
            if(statAverage.Type != Type)
                throw new Exception("StatAverage Type must be equal");
        }

        private void IsEqual(Stat stat)
        {
            if(stat.Type != Type)
                throw new ArgumentException($"Stat type: {stat.Type} - is not equal to Stat type");
        }

        public void Dispose()
        {
            _multiplierStats.Clear();
            _nonMultiplierStats.Clear();

            _multiplierStats = null;
            _nonMultiplierStats = null;
        }
    }
}