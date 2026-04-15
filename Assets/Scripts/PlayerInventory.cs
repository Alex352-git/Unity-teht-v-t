using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    public static PlayerInventory Instance { get; private set; }

    public int CurrentKeyID { get; private set; } = 0;

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            
            Destroy(gameObject);
        }
        else
        {
           
            Instance = this;
        }
    }

    public void PickUpKey(int keyID)
    {
        CurrentKeyID = keyID;
        Debug.Log("Poimittiin avain ID: " + keyID);
    }

    public bool HasKey(int keyID)
    {
        return CurrentKeyID == keyID;
    }

    public void UseKey()
    {
        CurrentKeyID = 0;
        Debug.Log("Avain käytetty ja poistettu inventaariosta. (Key removed)");
    }
}