namespace Source.Domain.Village
{
    public interface IDamageable : IAlive
    {
        public void Damage(float value);
    }
}