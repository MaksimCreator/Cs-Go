using UnityEngine;
using UnityEngine.AI;

public class AIFsmStateMovement : FsmState
{
    private readonly Transform[] _wayPoints;
    private readonly NavMeshAgent _agent;

    public AIFsmStateMovement(Fsm fsm, AnimatorEntity animator,Transform[] target,NavMeshAgent agent) : base(fsm, animator) 
    {
        _wayPoints = target;
        _agent = agent;
    }

    public override void Enter()
    => Animator.EnterMove();

    public override void Update()
    {

    }
}