using UnityEngine;

public class FsmStateMovement : FsmState
{
    private readonly IMove _moveController;
    private readonly CharacterController _player;

    public FsmStateMovement(Fsm fsm,AnimatorEntity animator,PlayerMove moveControler,CharacterController controller,Camera cameraPlayer) : base(fsm,animator) 
    {
        _moveController = moveControler;
        _player = controller;
    }

    public override void Enter()
    => Animator.Enter();

    public override void Update()
    => _player.Move(_moveController.Direction);
}
