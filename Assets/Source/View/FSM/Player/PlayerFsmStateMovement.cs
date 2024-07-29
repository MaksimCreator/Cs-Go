using UnityEngine;

public class PlayerFsmStateMovement : FsmState
{
    public Transform Transform;
    private readonly CharacterController _controller;
    private readonly IMove _playerMovement;

    public PlayerFsmStateMovement(Fsm fsm, AnimatorEntity animator, CharacterController controller, PlayerMovement playerMovement) : base(fsm, animator)
    {
        _controller = controller;
        _playerMovement = playerMovement;
        Transform = _controller.transform;
    }

    public override void Enter()
    => Animator.EnterMove();

    public override void Update()
    => _controller.Move(_playerMovement.Direction);
}
