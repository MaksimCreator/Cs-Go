using System;
using UnityEngine;

public sealed class Digle : Gun
{
    public Digle(Action activeRollbeck, AnimatorOverrideController controller, float speed, float damage, int allBullet, int maxBullet) : base(activeRollbeck, controller, speed, damage, allBullet, maxBullet) { }
}
