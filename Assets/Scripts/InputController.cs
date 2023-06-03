using UnityEngine;

public class InputController : MonoBehaviour
{
    public float InputX { get; private set; }
    public float InputY { get; private set; }

    private void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
    }
}