using TMPro;
using UnityEngine;

public class HandleLogin : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNickName;
    void Start()
    {
        playerNickName.text = Login.nickname;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
