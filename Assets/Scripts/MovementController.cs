using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundChecker;

    private Rigidbody2D _rigidbody2D;

    public bool IsGrounded { get; private set; }
    public float VelocityX => _rigidbody2D.velocity.x;
    public float VelocityY => _rigidbody2D.velocity.y;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckRadius, _groundLayer);
    }

    public void Move(Vector2 position)
    {
        _rigidbody2D.velocity = new Vector2(position.x, _rigidbody2D.velocity.y);
    }

    public void Jump(float jumpForce)
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.y, 0f);
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}