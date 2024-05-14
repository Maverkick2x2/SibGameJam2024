using System.Collections;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private HitObject _hitObjectPrefab;
    [SerializeField] private HitObject _hitAirObjectPrefab;
    [SerializeField] private Transform _upperTarget;
    [SerializeField] private Transform _lowerTarget;
    [SerializeField] private AnimatorController _animator;
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private float _hitSpawnTime;

    private PoolMono<HitObject> _hitPool;
    private PoolMono<HitObject> _hitAirPool;

    private void Start()
    {
        _hitPool = new PoolMono<HitObject>(_hitObjectPrefab, _poolCount, transform);
        _hitAirPool = new PoolMono<HitObject>(_hitAirObjectPrefab, _poolCount, transform);

        _hitPool.AutoExpand = _autoExpand;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.DedUpAttack();
        }

        if (Input.GetMouseButtonDown(1))
        {

            _animator.DedDownAttack();
        }
    }

    public void UpHit()
    {
        StartCoroutine(HitObjectSpawn(_hitAirPool, _upperTarget));
    }

    public void DownHit()
    {
        StartCoroutine(HitObjectSpawn(_hitPool, _lowerTarget));
    }

    private IEnumerator HitObjectSpawn<T>(PoolMono<T> pool, Transform target) where T : MonoBehaviour
    {
        yield return new WaitForSeconds(_hitSpawnTime);
        var cube = pool.GetFreeElement();
        cube.transform.position = target.position;
        yield return new WaitForSeconds(_hitSpawnTime);
        cube.gameObject.SetActive(false);
        yield return new WaitForSeconds(_hitSpawnTime);
    }
}
