using UnityEngine;

[RequireComponent(typeof(InputController), typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _jumpForce = 6f;
    [SerializeField] private int _jumpsCount = 1;

    private InputController _inputController;
    private CharacterController2D _characterController2D;
    private Vector3 _defaultScale;
    private bool _isFlipped = false;
    private int _currentJumpsCount = 0;

    private void Start()
    {
        _inputController = GetComponent<InputController>();
        _characterController2D = GetComponent<CharacterController2D>();

        _inputController.JumpPressed.AddListener(OnJumpPressed);

        _defaultScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        _characterController2D.Move(new Vector2(_inputController.InputX, 0f) * _moveSpeed);

        if (_characterController2D.IsGrounded && _currentJumpsCount > 0)
        {
            _currentJumpsCount = 0;
        }

        TryFlip();
    }

    private void OnJumpPressed()
    {
        _currentJumpsCount++;

        if (_currentJumpsCount < _jumpsCount)
        {
            _characterController2D.Jump(_jumpForce);
        }
    }

    private void TryFlip()
    {
        if ((_inputController.InputX > 0 && _isFlipped) || (_inputController.InputX < 0 && _isFlipped == false))
        {
            Flip();
        }
    }

    private void Flip()
    {
        float newScalex = _isFlipped ? _defaultScale.x : -_defaultScale.x;

        transform.localScale = new Vector3(newScalex, _defaultScale.y, _defaultScale.z);
        _isFlipped = !_isFlipped;
    }
}