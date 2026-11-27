using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardManager : MonoBehaviour
{
    public string url = "http://localhost:5139/leaderboard";
    public TMP_Text leaderboardText;

    public void GetLeaderboard()
    {
        StartCoroutine(GetLeaderboardCoroutine());
    }

    private IEnumerator GetLeaderboardCoroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.timeout = 8;
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                leaderboardText.text = "Palvelimeen ei saatu yhteyttä.";
                Debug.LogError(request.error);
                yield break;
            }

            string json = "{\"scores\":" + request.downloadHandler.text + "}";
            ShowLeaderboard(JsonUtility.FromJson<ScoreList>(json));
        }
    }

    private void ShowLeaderboard(ScoreList list)
    {
        leaderboardText.text = "TOP 5";
        for (int i = 0; i < list.scores.Length; i++)
        {
            ScoreApi score = list.scores[i];
            leaderboardText.text += $"\n{i + 1}. {score.name} - {score.points}";
        }
    }
}
