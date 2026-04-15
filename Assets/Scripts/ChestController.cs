using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Avaa arkun, jos pelaajalla on oikea avain ja h‰n painaa 'E'.
/// </summary>
public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator;
    [Tooltip("1 = Kulta (Gold), 2 = Hopea (Silver)")]
    [SerializeField] private int requiredKeyID;

    private bool isPlayerNear = false;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        // Fallback just in case you forget to drag the Animator in the Inspector
        if (chestAnimator == null)
        {
            chestAnimator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        // Only check for input if the player is standing in the trigger zone
        if (isPlayerNear && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryOpenChest();
        }
    }

    private void TryOpenChest()
    {
        if (playerInventory != null && playerInventory.HasKey(requiredKeyID))
        {
            chestAnimator.SetTrigger("Open");
            Debug.Log("Arkku avattu! (Chest opened!)");

            // playerInventory.UseKey(); // Uncomment if you want to consume the key
        }
        else
        {
            Debug.Log("V‰‰r‰ avain tai ei avainta! (Wrong key or no key!)");
        }
    }

    // Detect when player gets close to the chest
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            playerInventory = other.GetComponent<PlayerInventory>();
        }
    }

    // Detect when player walks away from the chest
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            playerInventory = null;
        }
    }
}