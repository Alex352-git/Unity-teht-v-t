[System.Serializable]
public class PlayerData
{
    public int health;
    public int score;

    public PlayerData(Player player)
    {
        health = player.GetComponent<Health>().CurrentHealth;
        score = player.Score;
    }
}