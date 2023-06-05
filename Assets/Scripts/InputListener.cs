using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
    public float InputX { get; private set; }

    [HideInInspector] public UnityEvent JumpPressed = new UnityEvent();

    private void Update()
    {
        InputX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
            JumpPressed.Invoke();
    }
}