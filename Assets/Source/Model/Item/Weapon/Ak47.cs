using System;
using UnityEngine;

public sealed class Ak47 : HeavyWeapons
{
    public Ak47(Action activeRollbeck,AnimatorOverrideController controller, float speed, float damage, int allBullet, int maxBullet) : base(activeRollbeck,controller, speed, damage, allBullet, maxBullet) { }
}
