using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        if (health == null)
        {
            Debug.LogError("Health-komponentti puuttuu");
        }

        Load();
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

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            Save();
        }
            if (Keyboard.current.lKey.wasPressedThisFrame)
            {
                Load();
        }
    }

    public void TakeDamage(int amount)
    {
        health.Modify(-amount);
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
    }

    // SAVE
    public void Save()
    {
        PlayerData playerData = new PlayerData(this);

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText($"{Application.dataPath}/playerData.json", json);
    }

    // LOAD
    public void Load()
    {
        string path = $"{Application.dataPath}/playerData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            health.CurrentHealth = playerData.health;
        }
    }
}