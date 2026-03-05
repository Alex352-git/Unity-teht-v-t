using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Luokka on vuorovaikutuksessa painikkeen kanssa.
/// </summary>
public class ButtonController : MonoBehaviour
{
    // Referenssi avattavaan arkkuun
    [SerializeField] private ChestController chest;

    void Update()
    {

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            chest.Open();
        }
    }
}
    
        
    
