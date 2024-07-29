using UnityEngine;

public sealed class Knife : Item
{
    public readonly int Damage;

    public Knife(AnimatorOverrideController controller,float speed,int damage) : base(controller,speed)
    {
        Damage = damage;
    }

    public void Attack()
    {

    }
}