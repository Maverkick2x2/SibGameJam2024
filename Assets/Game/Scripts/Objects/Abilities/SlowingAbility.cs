using UnityEngine;

public class SlowingAbility : MonoBehaviour
{
    private RandomMove[] _coinsRandomMoveObjects;

    private void Start()
    {
        _coinsRandomMoveObjects = FindObjectsOfType<RandomMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PhysicCharacterMovement characterMovement))
        {
            for (int i = 0; i < _coinsRandomMoveObjects.Length; i++)
            {
                _coinsRandomMoveObjects[i].Slow();
            }

            GameObject.FindGameObjectWithTag("Boost").GetComponent<SoundsPlayer>().PlaySound();
            EventManager.PlaySound();
            gameObject.SetActive(false);
        }
    }
}
