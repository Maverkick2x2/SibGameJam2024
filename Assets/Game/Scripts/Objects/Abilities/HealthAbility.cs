using UnityEngine;

public class HealthAbility : MonoBehaviour
{
    private float _randomValue;
    private Health _health;

    private void Start()
    {
        _health = FindObjectOfType<Health>();
        _randomValue = 10f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PhysicCharacterMovement characterMovement))
        {
            GameObject.FindGameObjectWithTag("Boost").GetComponent<SoundsPlayer>().PlaySound();
            EventManager.PlaySound();
            _health.AddHealth(_randomValue);
            gameObject.SetActive(false);
        }
    }
}
