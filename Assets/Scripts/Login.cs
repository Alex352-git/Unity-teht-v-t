using SQLite;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player
{
    [Column("pincode")]
    public string PinCode { get; set; }

    [Column("nick_name")]
    public string NickName { get; set; }
}

public class Login : MonoBehaviour
{
    private string database = $"{Application.dataPath}/AdventureGame.db";
    [SerializeField] private TMP_InputField pincode;
    public bool IsLoginOK { get; private set; }
    public static string nickname = "";

    public void HandleLogin()
    {
        var db = new SQLiteConnection(database);
        string sql = $"select * from Logins where pincode = '{pincode.text}'";
        var players = db.Query<player>(sql);

        if (players.Count != 0)
        {
            nickname = players[0].NickName;
            IsLoginOK = true;
        }

        db.Close();

        if (!IsLoginOK)
        {
            return;
        }

        SceneManager.LoadScene("AdventureGame");
    }
}