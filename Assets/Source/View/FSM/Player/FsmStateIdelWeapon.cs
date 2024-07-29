using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmStateIdelWeapon : FsmState
{
    public FsmStateIdelWeapon(Fsm fsm, AnimatorEntity animator) : base(fsm, animator) { }

    public override void Enter()
    => Animator.EnterIdelWeapon();
}
