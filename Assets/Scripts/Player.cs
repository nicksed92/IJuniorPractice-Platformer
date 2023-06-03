using UnityEngine;

[RequireComponent(typeof(InputController), typeof(CharacterController2D))]
public class Player : MonoBehaviour
{
    private InputController _inputController;
    private CharacterController2D _characterController2D;

    private void Start()
    {
        _inputController = GetComponent<InputController>();
        _characterController2D = GetComponent<CharacterController2D>();
    }

    private void FixedUpdate()
    {
        _characterController2D.Move(_inputController.InputX);
    }
}