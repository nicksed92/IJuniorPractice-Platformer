using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    public float VelocityX => _rigidbody2D.velocity.x;
    public float VelocityY => _rigidbody2D.velocity.y;

    public void Move(float positionX)
    {
        _rigidbody2D.velocity = new Vector2(positionX * _moveSpeed, _rigidbody2D.velocity.y);
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}