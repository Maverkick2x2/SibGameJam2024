using System.Collections;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [Header("Speed")]

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;

    [Header("Timers")]

    [SerializeField] private float _slowingTimer;
    [SerializeField] private float _breakTimer;
    [SerializeField] private float _flyAwayTimer;

    private Transform _target;
    private Rigidbody _rb;
    private AnimatorController _animator;
    private float _currentSpeed;

    public float Speed { get { return _moveSpeed; } set { _moveSpeed = value; } }


    private void Start()
    {
        _currentSpeed = _moveSpeed;
        _target = FindObjectOfType<Potato>().gameObject.transform;
        _animator = GetComponent<AnimatorController>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        SlowingAbility.OnSpeedMoveChangeEvent += Slow;
    }

    private void OnDisable()
    {
        SlowingAbility.OnSpeedMoveChangeEvent -= Slow;
    }

    private void FixedUpdate()
    {
        Vector3 targetDirection = _target.position - transform.position;
        Vector3 movementDirection = targetDirection.normalized;

        _rb.velocity = movementDirection * _currentSpeed;

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            Quaternion newRotation = Quaternion.Slerp(_rb.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rb.MoveRotation(newRotation);
        }
    }

    public void FlyAway()
    {
        _currentSpeed = -_currentSpeed * 15f;
        _animator.BugHit();
        StartCoroutine(FlyAwayCoroutine());
    }

    public void Break()
    {
        StartCoroutine(BreakCoroutine());
    }

    public void Slow()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Slowing());
        }
    }

    private void DeactivateBug()
    {
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private void SetSpeed()
    {
        _currentSpeed = _moveSpeed;
    }

    private IEnumerator FlyAwayCoroutine()
    {
        yield return new WaitForSecondsRealtime(_flyAwayTimer);
        _animator.BugFly();
        SetSpeed();
        DeactivateBug(); 
    }

    private IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(_breakTimer);
        SetSpeed();
        DeactivateBug();
    }

    private IEnumerator Slowing()
    {
        _currentSpeed = 0f;
        yield return new WaitForSeconds(_slowingTimer);
        SetSpeed();
    }
}
