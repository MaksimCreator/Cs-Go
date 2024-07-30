using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Ak47 : HeavyWeapons
{
    public Ak47(List<Vector3> wayRecoilWeapon, Action activeRollbeck, Transform muzzelPosition, ParticleSystem effectShoot, AudioSource audioShoot, AnimatorOverrideController controller, int allBullet, int maxBullet, float shakeIntensity, float speed) : base(wayRecoilWeapon, activeRollbeck, muzzelPosition, effectShoot, audioShoot, controller, allBullet, maxBullet, shakeIntensity, speed)
    {
    }
}