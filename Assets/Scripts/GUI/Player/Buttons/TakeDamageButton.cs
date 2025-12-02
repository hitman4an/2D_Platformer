
public class TakeDamageButton : HealButton
{
    private const int Damage = 25;
    
    public override void HandleClick()
    {
        _health.TakeDamage(Damage);
    }
}
