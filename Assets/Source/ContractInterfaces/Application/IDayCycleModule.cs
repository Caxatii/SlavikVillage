using Source.Domain.DayCycle;

namespace Source.Application.DayCycle.Modules
{
    public interface IDayCycleModule
    {
        public DayTimeType Type { get; }
        public void Handle();
    }
}