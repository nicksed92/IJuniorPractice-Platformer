using UnityEngine;

[RequireComponent(typeof(Animator), typeof(MovementController))]
public class AnimatorVelocityChanger : MonoBehaviour
{
    private MovementController _characterController2D;
    private Animator _animator;

    private int _velocityX = Animator.StringToHash("VelocityX");
    private int _velocityY = Animator.StringToHash("VelocityY");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController2D = GetComponent<MovementController>();
    }

    private void Update()
    {
        if (_velocityX != 0)
            _animator.SetFloat(_velocityX, _characterController2D.VelocityX);

        if (_velocityY != 0)
            _animator.SetFloat(_velocityY, _characterController2D.VelocityY);
    }
}