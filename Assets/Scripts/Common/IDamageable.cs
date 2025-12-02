public interface IDamageable
{
    public void TakeDamage(int damage) { }
    
    public void Heal(Potion potion) { }
    
    public void Heal(int value) { }
}
