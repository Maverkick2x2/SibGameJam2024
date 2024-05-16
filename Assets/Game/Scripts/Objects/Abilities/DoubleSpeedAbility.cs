using UnityEngine;

public class DoubleSpeedAbility : MonoBehaviour
{
    private PhysicCharacterMovement _physicCharacterMovement;
    private SoundsPlayer _soundsPlayer;

    private void Start()
    {
        _physicCharacterMovement = FindObjectOfType<PhysicCharacterMovement>();
        _soundsPlayer = GameObject.FindGameObjectWithTag("Boost").GetComponent<SoundsPlayer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PhysicCharacterMovement characterMovement))
        {
            _soundsPlayer.PlayAnotherSound();
            _physicCharacterMovement.IncreaseSpeed();
            gameObject.SetActive(false);
        }
    }
}
