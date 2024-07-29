using System;
using UnityEngine;

public abstract class HeavyWeapons : Weapon
{
    protected HeavyWeapons(Action activeRollbeck,AnimatorOverrideController controller, float speed, float damage, int allBullet, int maxBullet) : base(activeRollbeck,controller, speed, damage, allBullet, maxBullet) { }
}
