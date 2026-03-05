using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    private int score = 0;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
        UpdateScoreText();
    }



    public void Click()
    {
        score++;
        UpdateScoreText();
    }

    #region T‰h‰n tulee EndGame-metodi
    public void EndGame()
    {
        int highscore = PlayerPrefs.GetInt("Highscore", 0);

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.Save();
            highscoreText.text = "Highscore: " + score;

        }
        score = 0;
        UpdateScoreText();
        Debug.Log("Peli p‰‰tty");
    }


    #endregion

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    
}