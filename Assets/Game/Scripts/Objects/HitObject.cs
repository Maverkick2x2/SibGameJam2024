using UnityEngine;

public class HitObject : MonoBehaviour
{
    private PoolObject _pool;

    private void Start()
    {
        _pool = FindObjectOfType<PoolObject>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out FlyingBug flyBug))
        {
            TakeDamage(flyBug);
            flyBug.GetComponent<RandomMove>().FlyAway();
            flyBug.SetFightScore(flyBug.Reward);
        }

        else if (other.TryGetComponent(out Caterpillar caterpillar))
        {
            TakeDamage(caterpillar);
            caterpillar.GetComponent<RandomMove>().Break();
            caterpillar.SetScore(caterpillar.Reward);
        }
    }

    private void TakeDamage(Bug bug)
    {
        EventManager.CallCoinPickedUp(bug.Reward);
        EventManager.PlaySound();
        CreateRandomAbility();
    }

    private void CreateRandomAbility()
    {
        int rValueGross = Random.Range(0, 100);

        if (rValueGross < 10)
        {
            int rValueLocal = Random.Range(1, 4);

            if (rValueLocal == 1)
            {
                _pool.CreateAbilitySphere(_pool.HealhAbilityPool);
            }

            else if (rValueLocal == 2)
            {
                _pool.CreateAbilitySphere(_pool.SpeedPool);
            }

            else
            {
                _pool.CreateAbilitySphere(_pool.SlowPool);
            }
        }
    }
}
