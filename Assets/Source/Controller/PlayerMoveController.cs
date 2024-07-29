using UnityEngine;

public class PlayerMoveController
{
    private readonly Fsm _fsmMoveming;
    private readonly Fsm _fsmRotation;
    private readonly PlayerMovement _moveming;

    public PlayerMoveController(Fsm fsmMoveming, Fsm fsmRotation, PlayerMovement moveming)
    {
        _fsmMoveming = fsmMoveming;
        _fsmRotation = fsmRotation;
        _moveming = moveming;
    }

    public void Jump()
    => _moveming.Jump();

    public void Update(Vector2 direction,Vector2 rotate,float delta)
    {
        Exception.TryValueIsInvalideit(delta);

        Move(direction, delta);
        Rotate(rotate, delta);

        _moveming.Update(delta);
        _fsmMoveming.Update();
        _fsmRotation.Update();
    }

    public void FixedUpdate(float fixedDelta)
    {
        Exception.TryValueIsInvalideit(fixedDelta);
        _moveming.Slider(fixedDelta);
    }

    private void Move(Vector2 direction,float delta)
    {
        Exception.TryValueIsInvalideit(delta);

        if (direction != default)
        {
            _moveming.Move(direction, delta);
            _fsmMoveming.SetState<PlayerFsmStateMovement>();
        }
        else
        {
            _fsmMoveming.SetState<PlayerFsmStateIdel>();
        }
    }

    private void Rotate(Vector2 rotate, float delta)
    {
        Exception.TryValueIsInvalideit(delta);

        if (rotate != default)
        {
            _moveming.Rotate(rotate, delta);
            _fsmRotation.SetState<PlayerFsmStateRotate>();
        }
        else
        {
            _fsmRotation.SetState<PlayerFsmStateIdel>();
        }
    }
}
