using System;

namespace The_imp.Mono.Stats
{
    public interface IReadonlyStatAverage : IDisposable
    {
        public float Average { get; }
        public bool Has(Stat stat);
        public StatType Type { get; }
        public float DisposableAverage(StatAverage statAverage);
        
        public event Action<float> ValueChanged;
    }
}