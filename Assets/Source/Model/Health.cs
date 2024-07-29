using System;

public class Health
{
    private const int MinHealth = 0;

    public int MaxHealth { get; private set; }
    public int CurentHealth { get; private set; }

    public event Action onDead;

    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurentHealth = maxHealth;
    }
}
