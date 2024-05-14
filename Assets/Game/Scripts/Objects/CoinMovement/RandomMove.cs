using System.Collections;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _slowingTimer;

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
        _currentSpeed = _moveSpeed;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }

    private IEnumerator FlyAwayCoroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        _animator.BugFly();
        DeactivateBug();
    }

    private IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        DeactivateBug();
    }

    private IEnumerator Slowing()
    {
        _currentSpeed = 0f;
        yield return new WaitForSeconds(_slowingTimer);
        _currentSpeed = _moveSpeed;
        DeactivateBug();
    }
}
