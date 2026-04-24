using UnityEngine;
using UnityEngine.TextCore.Text;

public class Warrior : Character
{
    private void Start()
    {
        characterName = "Warrior";
        hp = 100;
    }

    public override void Attack()
    {
        Debug.Log(characterName + " hyökkää miekalla!");
    }
}