using UnityEngine;
using UnityEngine.TextCore.Text;

public class Mage : Character
{
    private void Start()
    {
        characterName = "Mage";
        hp = 80;
    }

    public override void Attack()
    {
        Debug.Log(characterName + " ampuu tulipallon!");
    }
}