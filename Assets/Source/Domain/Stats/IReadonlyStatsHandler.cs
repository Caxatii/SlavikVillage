namespace Source.Domain.Stats
{
    public interface IReadonlyStatsHandler
    {
        public bool Has(StatType statType);
        
        public bool Has(Stat stat);
        
        public float GetAverage(StatType statType);

        public IReadonlyStatAverage GetSafeStatAverage(StatType statType);
    }
}