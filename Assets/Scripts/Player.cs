using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    private Health health;

    public int Score;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;

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
        UpdateUI();
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
        UpdateUI();
    }

    public void Heal(int amount)
    {
        health.Modify(amount);
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (hpText != null && health != null)
        {
            hpText.text = $"HP: {health.CurrentHealth}";
        }

        if (scoreText != null)
        {
            scoreText.text = $"Score: {Score}";
        }
    }

    public void Save()
    {
        PlayerData playerData = new PlayerData(this);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText($"{Application.dataPath}/playerData.json", json);
    }

    public void Load()
    {
        string path = $"{Application.dataPath}/playerData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            health.CurrentHealth = playerData.health;
            Score = playerData.score;

            UpdateUI();
        }
    }
}