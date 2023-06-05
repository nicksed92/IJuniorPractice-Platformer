using UnityEngine;

[RequireComponent(typeof(Animator), typeof(MovementController))]
public class AnimatorVelocityChanger : MonoBehaviour
{
    private MovementController _movementController;
    private Animator _animator;

    private int _velocityX = Animator.StringToHash("VelocityX");
    private int _velocityY = Animator.StringToHash("VelocityY");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        if (_velocityX != 0)
            _animator.SetFloat(_velocityX, _movementController.VelocityX);

        if (_velocityY != 0)
            _animator.SetFloat(_velocityY, _movementController.VelocityY);
    }
}