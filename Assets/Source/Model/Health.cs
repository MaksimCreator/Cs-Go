using System;

public class Health
{
    private const int MinHealth = 0;

    public const int MaxHealth = 100;
    public int CurentHealth { get; private set; }

    public event Action onDead;

    public Health()
    {
        CurentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (CurentHealth == 0)
            throw new InvalidOperationException();

        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        if (CurentHealth - damage <= 0)
            CurentHealth = 0;
        else
            CurentHealth -= damage;

        if(CurentHealth <= 0)
            onDead?.Invoke();
    }
}
