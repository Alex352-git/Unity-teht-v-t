using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    [Tooltip("1 = Kulta (Gold), 2 = Hopea (Silver)")]
    [SerializeField] private int keyID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (PlayerInventory.Instance != null)
            {
                PlayerInventory.Instance.PickUpKey(keyID);
                Destroy(gameObject);
            }
        }
    }
}