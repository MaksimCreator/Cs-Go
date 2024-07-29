using System;
using UnityEngine;

public sealed class Usp : Gun
{
    public Usp(Action activeRollbeck, AnimatorOverrideController controller, float speed, float damage, int allBullet, int maxBullet) : base(activeRollbeck, controller, speed, damage, allBullet, maxBullet) { }
}
