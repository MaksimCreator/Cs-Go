using UnityEngine;

public abstract class Item
{
    public readonly AnimatorOverrideController AnimationController;
    public readonly float Speed;

    protected Item(AnimatorOverrideController controller,float speed)
    {
        AnimationController = controller;
        Speed = speed;
    }
}
