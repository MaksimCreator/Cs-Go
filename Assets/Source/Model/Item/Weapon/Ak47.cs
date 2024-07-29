using System;
using UnityEngine;

public sealed class Ak47 : HeavyWeapons
{
    public Ak47(Action activeRollbeck, Transform muzzelPosition, ParticleSystem effectShoot, AudioSource audioShoot, AnimatorOverrideController controller, int allBullet, int maxBullet, float speed) : base(activeRollbeck, muzzelPosition, effectShoot, audioShoot, controller, allBullet, maxBullet, speed) { }
}
