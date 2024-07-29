using UnityEngine;

public class PlayerMovement : IMove, IRotate,IPosition
{
    private readonly Transform _camera;
    private readonly Transform _player;
    private readonly CharacterController _controller;
    private readonly ISpeed _playerPresenter;
    private readonly float _gravety;
    private readonly float _powerJump;
    private readonly float _sliderForce;
    private readonly float _maxRotationY;
    private readonly float _minRotationY;
    private readonly float _raycastLench = 1.5f;

    private Vector3 _direction;
    private Vector2 _rotation;

    public Vector3 Position => _player.position;
    public Vector3 Direction 
    {
        get
        {
            Vector2 direction = _direction;
            _direction = Vector3.zero;
            return direction;
        }
    }
    public Vector2 Rotation
    { 
        get
        {
            Vector2 rotate = _rotation;
            _rotation = Vector2.zero;
            return rotate;
        }
    }

    public PlayerMovement(Camera cameraPlayer,CharacterController controller,InventaryPresenter playerInventary, float gravety, float slopeForce,float powerJump,float maxRotation,float minRotation)
    {
        _camera = cameraPlayer.transform;
        _player = controller.transform;
        _playerPresenter = playerInventary;
        _gravety = gravety;
        _sliderForce = slopeForce;
        _powerJump = powerJump;
        _maxRotationY = maxRotation;
        _minRotationY = minRotation;
    }

    public void Jump()
    {
        if (_controller.isGrounded)
            _direction += Vector3.up * _powerJump;
    }

    public void Move(Vector2 direction, float delta)
    {
        Exception.TryValueIsInvalideit(delta);
        _direction += new Vector3(direction.x * delta * _playerPresenter.Speed, direction.y * delta * _playerPresenter.Speed);
    }

    public void Rotate(Vector2 rotation,float delta)
    {
        Exception.TryValueIsInvalideit(delta);
        _rotation.x += rotation.x * delta;
        LimitRotation(rotation.y * delta);
    }

    public void Update(float delta)
    {
        Exception.TryValueIsInvalideit(delta);

        if (_controller.isGrounded == false)
            _direction -= Vector3.down * _gravety * delta;
    }

    public void Slider(float delta)
    {
        Exception.TryValueIsInvalideit(delta);

        if (Physics.Raycast(_player.position, Vector3.down, out RaycastHit hit, _raycastLench) == false)
            return;

        if (Vector3.Angle(hit.normal, Vector2.up) <= _controller.slopeLimit)
            return;

        float speedSliding = _sliderForce * delta;

        _direction.x += (1 - hit.normal.y) * hit.normal.x * speedSliding;
        _direction.z += (1 - hit.normal.y) * hit.normal.z * speedSliding;
        _direction.y -= speedSliding;
    }

    private void LimitRotation(float deltaRotationY)
    {
        Vector3 angelEuler = _camera.rotation.eulerAngles;
        angelEuler.x = angelEuler.x > 180 ? angelEuler.x - 360 : angelEuler.x;
        angelEuler.x = Mathf.Clamp(angelEuler.x + deltaRotationY, _minRotationY, _maxRotationY);
        _rotation.y = angelEuler.x;
    }
}