using System.Collections;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [Header("Prefabs")]

    [SerializeField] private Bug _bugPrefab;
    [SerializeField] private FlyingBug _flyBugPrefab;
    [SerializeField] private HealthAbility _healthAbilityPrefab;
    [SerializeField] private DoubleSpeedAbility _speedAbilityPrefab;
    [SerializeField] private SlowingAbility _slowAbilityPrefab;

    [Header("Timers")]

    [SerializeField] private float _bugTimerCounter;
    [SerializeField] private float _flyBugTimerCounter;
    [SerializeField] private float _bugTimer;
    [SerializeField] private float _flyBugTimer;

    [Header("Pools")]

    private PoolMono<Bug> _bugPool;
    private PoolMono<FlyingBug> _flyBugPool;
    private PoolMono<HealthAbility> _healthAbilityPool;
    private PoolMono<DoubleSpeedAbility> _speedPool;
    private PoolMono<SlowingAbility> _slowPool;

    public PoolMono<HealthAbility> HealhAbilityPool { get { return _healthAbilityPool; } }
    public PoolMono<DoubleSpeedAbility> SpeedPool { get { return _speedPool; } }
    public PoolMono<SlowingAbility> SlowPool { get { return _slowPool; } }

    [Header("Another")]

    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private int _spawnDistanceValue;

    private void Start()
    {
        InitializePools();
        ResetTimer();
    }

    private void ResetTimer()
    {
        _bugTimer = _bugTimerCounter;
        _flyBugTimer = _flyBugTimerCounter;
    }

    private void InitializePools()
    {
        CreatePool(ref _bugPool, _bugPrefab);
        CreatePool(ref _flyBugPool, _flyBugPrefab);
        CreatePool(ref _healthAbilityPool, _healthAbilityPrefab);
        CreatePool(ref _speedPool, _speedAbilityPrefab);
        CreatePool(ref _slowPool, _slowAbilityPrefab);
    }

    private void CreatePool<T>(ref PoolMono<T> pool, T prefab) where T : MonoBehaviour
    {
        pool = new PoolMono<T>(prefab, _poolCount, transform);
        pool.AutoExpand = _autoExpand;
    }

    private void Update()
    {
        ElapseTimer();
    }

    private void ElapseTimer()
    {
        _bugTimer -= Time.deltaTime;
        _flyBugTimer -= Time.deltaTime;

        if (_bugTimer <= 0)
        {
            CreateBug(-0.5f, _bugPool);
            _bugTimer = 0.5f;
        }

        if (_flyBugTimer <= 0)
        {
            CreateBug(0.5f, _flyBugPool);
            _flyBugTimer = 1f;
        }
    }

    private void CreateBug<T>(float y, PoolMono<T> pool) where T : MonoBehaviour
    {
        var rX = Random.Range(-1f, 1f) * _spawnDistanceValue;
        var rZ = Random.Range(-1f, 1f) * _spawnDistanceValue;

        if (rX > -7f && rX < 7f || rZ > -7f && rZ < 7f) return;

        var rPosition = new Vector3(rX, y, rZ);
        var cube = pool.GetFreeElement();
        cube.transform.position = rPosition;
        cube.transform.rotation = Quaternion.identity;
    }

    public void CreateAbilitySphere<T>(PoolMono<T> pool) where T : MonoBehaviour
    {
        var rX = Random.Range(-10f, 10f);
        var rZ = Random.Range(-10f, 10f);
        var y = 0;

        var rPosition = new Vector3(rX, y, rZ);

        var cube = pool.GetFreeElement();
        cube.transform.position = rPosition;

        StartCoroutine(AbilityLifeTime(cube.gameObject));
    }

    private IEnumerator AbilityLifeTime(GameObject ability)
    {
        yield return new WaitForSeconds(10f);
        ability.SetActive(false);
    }

}
