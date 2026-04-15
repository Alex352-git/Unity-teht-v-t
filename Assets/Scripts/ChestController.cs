using UnityEngine;
using UnityEngine.InputSystem;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator;
    [Tooltip("1 = Kulta (Gold), 2 = Hopea (Silver)")]
    [SerializeField] private int requiredKeyID;

    private bool isPlayerNear = false;

    private void Awake()
    {
        if (chestAnimator == null)
        {
            chestAnimator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        if (isPlayerNear && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryOpenChest();
        }
    }

    private void TryOpenChest()
    {
        
        if (PlayerInventory.Instance != null && PlayerInventory.Instance.HasKey(requiredKeyID))
        {
            chestAnimator.SetTrigger("Open");
            Debug.Log("Arkku avattu! (Chest opened!)");

            
            PlayerInventory.Instance.UseKey();
        }
        else
        {
            Debug.Log("V‰‰r‰ avain tai ei avainta! (Wrong key or no key!)");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}