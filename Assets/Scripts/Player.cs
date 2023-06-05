using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputListener))]
public class Player : Person
{
    [SerializeField] private float _jumpForce = 6f;
    [SerializeField] private int _jumpsCount = 1;

    private InputListener _inputController;
    private int _currentJumpsCount;

    public static UnityEvent<int> Collected = new UnityEvent<int>();

    protected override void Start()
    {
        base.Start();

        _inputController = GetComponent<InputListener>();
        _inputController.JumpPressed.AddListener(OnJumpPressed);

        ResetJumps();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (CharacterController2D.IsGrounded && _currentJumpsCount > 0)
        {
            ResetJumps();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICollectable collectable))
        {
            Collected.Invoke(collectable.Collect());
        }
    }

    protected override void Move()
    {
        CharacterController2D.Move(new Vector2(_inputController.InputX, 0f) * MoveSpeed);
    }

    protected override void TryFlip()
    {
        if ((_inputController.InputX > 0 && IsFlipped) || (_inputController.InputX < 0 && IsFlipped == false))
        {
            Flip();
        }
    }

    private void OnJumpPressed()
    {
        _currentJumpsCount++;

        if (_currentJumpsCount < _jumpsCount)
        {
            CharacterController2D.Jump(_jumpForce);
        }
    }

    private void ResetJumps()
    {
        _currentJumpsCount = 0;
    }
}