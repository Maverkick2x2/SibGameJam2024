using System;
using UnityEngine;

public class SlowingAbility : MonoBehaviour
{
    public static event Action OnSpeedMoveChangeEvent;

    private SoundsPlayer _soundsPlayer;

    private void Start()
    {
        _soundsPlayer = GameObject.FindGameObjectWithTag("Boost").GetComponent<SoundsPlayer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PhysicCharacterMovement characterMovement))
        {
            OnSpeedMoveChangeEvent?.Invoke();
            _soundsPlayer.PlaySound();
            EventManager.PlaySound();
            gameObject.SetActive(false);
        }
    }
}
