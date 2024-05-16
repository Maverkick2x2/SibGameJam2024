using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static event Action<int> OnSceneLoadedEvent;

    [SerializeField] ScoreView _scoreView;

    private int _score;

    public int ScoreValue { get { return _score; } }
    
    private void Awake()
    {
        EventManager.CoinPickedUp.AddListener(Increase);
    }

    private void Start()
    {
        _score = 0;
    }

    public void Increase(int value)
    {
        _score += value;

        _scoreView.SetScore(_score);

        if (_score >= 1000)
        {
            OnSceneLoadedEvent?.Invoke(3);
        }
    }
}
