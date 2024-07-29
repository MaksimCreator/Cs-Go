using System;
using UnityEngine;

public abstract class HeavyWeapons : Weapon
{
    protected HeavyWeapons(Action activeRollbeck, Transform muzzelPosition, ParticleSystem effectShoot, AudioSource audioShoot, AnimatorOverrideController controller, int allBullet, int maxBullet, float speed) : base(activeRollbeck, muzzelPosition, effectShoot, audioShoot, controller, allBullet, maxBullet, speed) { }
}

