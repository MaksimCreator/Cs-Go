using UnityEngine.AI;

public class AIFsmStateSwithGun : FsmStateSwithGun
{
    private NavMeshAgent _agent;
    private ISpeed _inventary;

    public AIFsmStateSwithGun(Fsm fsm, AnimatorEntity animator, InventaryPresenter inventary,NavMeshAgent agent) : base(fsm, animator, inventary)
    {
        _agent = agent;
        _inventary = inventary;
    }

    public override void Enter()
    {
        _agent.speed = _inventary.Speed;
        base.Enter();
    }
}