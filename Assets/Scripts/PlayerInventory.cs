using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // The player only carries one key. 0 = No Key, 1 = Gold, 2 = Silver.
    public int CurrentKeyID { get; private set; } = 0;

    public void PickUpKey(int keyID)
    {
        CurrentKeyID = keyID;
        Debug.Log("Picked up key ID: " + keyID);
    }

    public bool HasKey(int keyID)
    {
        return CurrentKeyID == keyID;
    }

    // Optional: Call this if you want the key to disappear from inventory after use
    public void UseKey()
    {
        CurrentKeyID = 0;
    }
}