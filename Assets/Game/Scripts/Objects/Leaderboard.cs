using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Text _leaderboardText;

    private void Start()
    {
        _leaderboardText.text = "";
        for (int i = 1; i <= 10; i++)
        {
            int highscore = PlayerPrefs.GetInt("Highscore_" + i, 0);
            if (i == 1)
            {
                _leaderboardText.text += i + ". " + highscore + " - New Score!!! " + "\n";
                continue;
            }
            _leaderboardText.text += i + ". " + highscore + "\n";
        }
    }

    public static void AddScore(int score)
    {
        List<int> scores = new List<int>();

        for (int i = 1; i <= 10; i++)
        {
            int highscore = PlayerPrefs.GetInt("Highscore_" + i, 0);
            scores.Add(highscore);
        }

        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a));

        for (int i = 1; i <= 10; i++)
        {
            PlayerPrefs.SetInt("Highscore_" + i, scores[i - 1]);
        }
    }
}
