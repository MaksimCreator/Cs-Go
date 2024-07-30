using System;
using UnityEngine;

public class AnimatorEntity
{
    private Animator _animator;
    private AnimationClip[] _clipsAttack;

    public AnimatorEntity(Animator animator)
    {
        _animator = animator;
    }

    public void IdelWeapon()
    => StartAnimation(AnimatorConstant.IdelWeapon, Constant.LayerAttack);

    public void Move()
    => StartAnimation(AnimatorConstant.Move,Constant.LayerMove);

    public void Rollbeck() 
    => StartAnimation(AnimatorConstant.Rollbeck, Constant.LayerAttack);

    public void Idel() 
    => StartAnimation(AnimatorConstant.Idel,Constant.LayerMove);

    public void Attack()
    => StartAnimation(AnimatorConstant.Attack, Constant.LayerAttack);

    public void Jump()
    => StartAnimation(AnimatorConstant.Jump,Constant.LayerMove);

    public void SwithGun(AnimatorOverrideController controller)
    {
        StartAnimation(AnimatorConstant.SwithGunExit, Constant.LayerAttack);

        Timer.StartTimer(GetLencghAnimationClip(AnimatorConstant.SwithGunEnter, _clipsAttack), () => 
        {
            _clipsAttack = controller.animationClips;
            _animator.runtimeAnimatorController = controller;
            StartAnimation(AnimatorConstant.SwithGunEnter, Constant.LayerAttack);
        });
    }

    public float GetLenghAnimationRollbeck()
    => GetLencghAnimationClip(AnimatorConstant.Rollbeck,_clipsAttack) + Constant.TimeTransition;

    public float GetLenghAnimationSwithGun(AnimatorOverrideController controller)
    => GetLencghAnimationClip(AnimatorConstant.SwithGunEnter, _clipsAttack) + GetLencghAnimationClip(AnimatorConstant.SwithGunExit, controller.animationClips) + Constant.TimeTransition * 2;

    private void StartAnimation(int id,int layer)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(layer);

        if(stateInfo.shortNameHash != id)
            _animator.CrossFade(id, Constant.TimeTransition);
    }

    private float GetLencghAnimationClip(int animationId,AnimationClip[] clips)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].GetInstanceID() == animationId)
                return clips[i].length;
        }
        throw new InvalidOperationException();
    }
}
