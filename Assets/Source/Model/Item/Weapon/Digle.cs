using System;
using UnityEngine;

public sealed class Digle : Gun
{
    public Digle(Action activeRollbeck, Transform muzzelPosition, ParticleSystem effectShoot, AudioSource audioShoot, AnimatorOverrideController controller, int allBullet, int maxBullet, float speed) : base(activeRollbeck, muzzelPosition, effectShoot, audioShoot, controller, allBullet, maxBullet, speed) { }
}
