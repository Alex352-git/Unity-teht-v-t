using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Player vastaa pelaajan toiminnasta (liikkuminen, hy�kk�ys).
/// </summary>
public class Player : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        // TODO: hae Health-komponentti
        health = GetComponent<Health>();
    }

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError("Health-komponentti puuttuu");
        }

        TakeDamage(1);
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            TakeDamage(1);
        }

        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            Heal(1);
        }
    }

    public void TakeDamage(int amount)
    {
        // TODO: v�henn� el�m�� Healthin kautta
        health.Modify(-amount);
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
    }

}

