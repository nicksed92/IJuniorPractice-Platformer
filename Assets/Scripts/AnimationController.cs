using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController2D))]
public class AnimationController : MonoBehaviour
{
    private CharacterController2D _characterController2D;
    private Animator _animator;

    private int _velocityX = Animator.StringToHash("VelocityX");
    private int _velocityY = Animator.StringToHash("VelocityY");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController2D = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        _animator.SetFloat(_velocityX, _characterController2D.VelocityX);
        _animator.SetFloat(_velocityY, _characterController2D.VelocityY);
    }
}