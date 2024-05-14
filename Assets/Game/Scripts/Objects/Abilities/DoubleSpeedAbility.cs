using UnityEngine;

public class DoubleSpeedAbility : MonoBehaviour
{

    private PhysicCharacterMovement _physicCharacterMovement;

    private void Start()
    {
        _physicCharacterMovement = FindObjectOfType<PhysicCharacterMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PhysicCharacterMovement characterMovement))
        {
            GameObject.FindGameObjectWithTag("Boost").GetComponent<SoundsPlayer>().PlaySound();
            _physicCharacterMovement.IncreaseSpeed();
            EventManager.PlaySound();
            gameObject.SetActive(false);
        }
    }
}
