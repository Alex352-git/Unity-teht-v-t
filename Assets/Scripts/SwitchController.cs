using UnityEngine;
using UnityEngine.InputSystem;
public class SwitchController : MonoBehaviour
{
    [SerializeField] private LightController lamp;

    private void Update()
    {
        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            lamp.TurnOn();
        }

        if (Gamepad.current.leftTrigger.wasPressedThisFrame)
        {
            lamp.TurnOff();
        }
    }
}