using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int hp;

    public virtual void Attack()
    {
        Debug.Log(characterName + " hyökkää!");
    }

    public virtual void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log(characterName + " otti vahinkoa " + amount + ". HP on nyt: " + hp);
    }
}