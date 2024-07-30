using System;
using UnityEngine;
using DG.Tweening;

public static class CameraRecoil
{
    public static Tween GetRecoil(Camera camera,float timeAnimation,float shakeIntensity)
    {
        if (camera == null)
            throw new InvalidOperationException(nameof(camera));

        return camera.transform.DOShakePosition(timeAnimation, Vector3.back * shakeIntensity,1);
    }
}
