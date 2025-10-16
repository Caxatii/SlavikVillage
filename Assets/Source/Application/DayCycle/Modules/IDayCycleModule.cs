using Source.Domain.DayCycle;

namespace Source.Application
{
    public interface IDayCycleModule
    {
        public DayTimeType Type { get; }
        public void Handle();
    }
}