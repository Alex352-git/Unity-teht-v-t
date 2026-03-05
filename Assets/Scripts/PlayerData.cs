[System.Serializable]
public class PlayerData
{
    // Talletettavat tilatiedot
    public int health;

    // Konstruktori, joka alustaa muuttujat
    public PlayerData(Player player)
    {
        // Pyydä Player luokalta pelaajan terveys ja tallenna se muuttujaan
        health = player.GetComponent<Health>().CurrentHealth; 
    }
}

