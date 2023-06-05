using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class Person : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed = 4f;

    protected MovementController CharacterController2D;
    protected Vector3 DefaultScale;
    protected bool IsFlipped;

    protected virtual void Start()
    {
        CharacterController2D = GetComponent<MovementController>();
        DefaultScale = transform.localScale;
        IsFlipped = false;
    }

    protected virtual void FixedUpdate()
    {
        TryFlip();
        Move();
    }

    protected virtual void TryFlip() { }

    protected virtual void Move() { }

    protected void Flip()
    {
        float newScalex = IsFlipped ? DefaultScale.x : -DefaultScale.x;

        transform.localScale = new Vector3(newScalex, DefaultScale.y, DefaultScale.z);
        IsFlipped = !IsFlipped;
    }
}