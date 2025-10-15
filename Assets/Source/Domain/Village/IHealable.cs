namespace Source.Domain.Village
{
    public interface IHealable : IAlive
    {
        public void Heal(float value);
    }
}