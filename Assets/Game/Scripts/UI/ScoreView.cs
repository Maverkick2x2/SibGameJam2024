using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text _scoreText;
    [SerializeField] private Score _score;
    [SerializeField] private string _template;

    private void Awake()
    {
        _scoreText = GetComponent<Text>();
    }

    public void SetScore(int value)
    {
        _scoreText.text = string.Format(_template, value);
    }

    public void ShowTotalScore()
    {
        _scoreText.text = string.Format(_template, _score.ScoreValue);
        ShowLeaderboards();
    }

    public void ShowLeaderboards()
    {
        Leaderboard.AddScore(_score.ScoreValue);
    }
}
