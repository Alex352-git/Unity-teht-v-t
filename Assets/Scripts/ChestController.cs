using UnityEngine;

/// <summary>
/// Avaa arkun
/// </summary>
public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator;


    public void Open()
    {

        chestAnimator.SetTrigger("Open");
        Debug.Log("Open chest");
    }
}
