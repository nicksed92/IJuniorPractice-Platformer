using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Enemy : Person
{
    [SerializeField] private float _rayDistance = 0.5f;
    [SerializeField] private Transform _raycastWallChecker;
    [SerializeField] private Transform _raycastGroundChecker;

    private RaycastHit2D _raycastHit2D;
    private Vector2 _moveDIrection = Vector2.left;
    private Vector2 _wallCheckDirection = Vector2.left;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Move()
    {
        CharacterController2D.Move(_moveDIrection * MoveSpeed);
    }

    protected override void TryFlip()
    {
        if (CheckWallOnWay() || CheckGroundOnWay() == false)
        {
            _moveDIrection = -_moveDIrection;
            _wallCheckDirection = -_wallCheckDirection;
            Flip();
        }
    }

    private bool CheckWallOnWay()
    {
        return CheckColliderOnWay(_raycastWallChecker.position, _wallCheckDirection);
    }

    private bool CheckGroundOnWay()
    {
        return CheckColliderOnWay(_raycastGroundChecker.position, Vector2.down);
    }

    private bool CheckColliderOnWay(Vector2 startPosition, Vector2 direction)
    {
        _raycastHit2D = Physics2D.Raycast(startPosition, direction, _rayDistance);
        return _raycastHit2D.collider != null;
    }
}
