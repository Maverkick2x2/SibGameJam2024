using System;
using UnityEngine.Events;

public class EventManager
{
    public static readonly UnityEvent<int> CoinPickedUp = new UnityEvent<int>();

    public static event Action OnAudioClipUpdateEvent;

    public static void CallCoinPickedUp(int reward)
    {
        if (CoinPickedUp != null)
            CoinPickedUp.Invoke(reward);
    }

    public static void PlaySound()
    {
        OnAudioClipUpdateEvent?.Invoke();
    }
}
