using UnityEngine;
using UnityEngine.InputSystem;

public class InputRouter
{
    private readonly Input _input = new();
    private readonly InputPlayerAttack _inputAttack;
    private readonly PlayerMoveController _controller;

    public InputRouter(InputPlayerAttack attack,PlayerMoveController controller)
    {
        _inputAttack = attack;
        _controller = controller;
    }

    public void Enable()
    {
        _input.Player.SwithGunFirst.performed += FirstSwithWeapon;
        _input.Player.SwithGunSecond.performed += SecondSwithWeapon;
        _input.Player.SwithGunThird.performed += ThirdSwithWeapon;
        _input.Player.Rollbeck.performed += Rollbeck;
        _input.Player.Jump.performed += Jump;
    }

    public void Disable()
    {
        _input.Player.SwithGunFirst.performed -= FirstSwithWeapon;
        _input.Player.SwithGunSecond.performed -= SecondSwithWeapon;
        _input.Player.SwithGunThird.performed -= ThirdSwithWeapon;
        _input.Player.Rollbeck.performed -= Rollbeck;
        _input.Player.Jump.performed -= Jump;
    }

    public void Update(float delta)
    {
        Exception.TryValueIsInvalideit(delta);
        Vector2 direction = default;
        Vector2 rotation = default;

        if (IsPhase(_input.Player.Move))
            direction = _input.Player.Move.ReadValue<Vector2>();
        if(IsPhase(_input.Player.Rotation))
            rotation = _input.Player.Rotation.ReadValue<Vector2>();

        _controller.Update(direction,rotation,delta);
        _inputAttack.Update(IsPhase(_input.Player.Shoot));
    }

    public void FixedUpdate(float fixedUpdate)
    => _controller.FixedUpdate(fixedUpdate);

    private void Rollbeck(InputAction.CallbackContext obj)
    => _inputAttack.Rollbeck();

    private void Jump(InputAction.CallbackContext obj)
    => _controller.Jump();

    private void FirstSwithWeapon(InputAction.CallbackContext obj)
    => _inputAttack.SwithWeapon(0);

    private void SecondSwithWeapon(InputAction.CallbackContext obj)
    => _inputAttack.SwithWeapon(1);

    private void ThirdSwithWeapon(InputAction.CallbackContext obj)
    => _inputAttack.SwithWeapon(2);

    private bool IsPhase(InputAction action)
    => action.phase == InputActionPhase.Performed;
}
