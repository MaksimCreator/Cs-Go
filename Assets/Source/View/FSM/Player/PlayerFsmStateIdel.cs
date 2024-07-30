using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFsmStateIdel : FsmState
{
    public PlayerFsmStateIdel(Fsm fsm, AnimatorEntity animator) : base(fsm, animator) { }

    public override void Enter()
    => Animator.Idel();
}
