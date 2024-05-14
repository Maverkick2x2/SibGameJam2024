using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _timerFilling;

    [SerializeField] private float _maxTimer;
    [SerializeField] private float _currenttimer;

    public float CurrentTimer { get { return _currenttimer; } set { _currenttimer = value; } }

    public float MaxTimer { get { return _maxTimer; } }

    public static event Action OnElapseTimeUpdateEvent;

    private void Start()
    {
        _currenttimer = _maxTimer;
    }

    private void Update()
    {
        Expire();
    }

    private void Expire()
    {
        _currenttimer -= Time.deltaTime;
        float _timerPercentage = _currenttimer / _maxTimer;

        _timerFilling.fillAmount = _timerPercentage;
        _timerFilling.color = _gradient.Evaluate(_timerPercentage);

        if (_currenttimer <= 0)
        {
            OnElapseTimeUpdateEvent?.Invoke();
            _currenttimer = _maxTimer;
            Time.timeScale = 0;
        }
    }
}
