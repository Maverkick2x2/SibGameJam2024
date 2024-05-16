using UnityEngine;

public class HealthAbility : MonoBehaviour
{
    private float _randomValue;
    private Health _health;
    private SoundsPlayer _soundsPlayer;

    private void Start()
    {
        _health = FindObjectOfType<Health>();
        _randomValue = 10f;
        _soundsPlayer = GameObject.FindGameObjectWithTag("Boost").GetComponent<SoundsPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PhysicCharacterMovement characterMovement))
        {
            _soundsPlayer.PlayAnotherSound();
            _health.AddHealth(_randomValue);
            gameObject.SetActive(false);
        }
    }
}
