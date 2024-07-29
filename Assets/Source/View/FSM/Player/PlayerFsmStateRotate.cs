using UnityEngine;

public class PlayerFsmStateRotate : FsmState
{
    private readonly IRotate _moveController;
    private readonly Transform _player;
    private readonly Transform _cameraPlayer;

    public PlayerFsmStateRotate(Fsm fsm, AnimatorEntity animator, Transform player, Camera PlayerCamera, PlayerMovement rotate) : base(fsm, animator)
    {
        _player = player;
        _cameraPlayer = PlayerCamera.transform;
        _moveController = rotate;
    }

    public override void Update()
    {
        _player.Rotate(new Vector3(0,_moveController.Rotation.x,0));
        _cameraPlayer.rotation = Quaternion.Euler(-_moveController.Rotation.y, 0, 0);
    }
}