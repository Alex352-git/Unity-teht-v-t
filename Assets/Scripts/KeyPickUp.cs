using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [Tooltip("1 = Kulta (Gold), 2 = Hopea (Silver)")]
    [SerializeField] private int keyID;

    // Triggered when the player walks into the key's collider
    private void OnTriggerEnter(Collider other)
    {
        // Make sure the object walking into the key has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Use GetComponent to find the inventory
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                inventory.PickUpKey(keyID);
                Destroy(gameObject); // Remove the key from the game world
            }
        }
    }
}