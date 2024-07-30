using UnityEngine;

public sealed class Knife : Item
{
    private readonly AnimatorEntity _animator;
    public readonly int Damage;

    public Knife(AnimatorOverrideController controller,AnimatorEntity animator,float speed,int damage) : base(controller,speed)
    {
        Damage = damage;
        _animator = animator;
    }

    public void Attack()
    => _animator.Attack();
}