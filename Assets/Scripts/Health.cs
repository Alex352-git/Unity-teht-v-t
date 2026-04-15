using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private TextMeshProUGUI healthText;

    private int currentHealth;

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            UpdateHealthText();
        }
    }

    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void Modify(int amount)
    {
        CurrentHealth += amount; // IMPORTANT: use the property

        Debug.Log("Health: " + CurrentHealth);
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + CurrentHealth;
        }
    }
}