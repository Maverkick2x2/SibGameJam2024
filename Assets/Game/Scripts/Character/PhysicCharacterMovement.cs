using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicCharacterMovement : MonoBehaviour
{
    [SerializeField] private AnimatorController animatorController;

    [Header("Character Movement Stats")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _rotateSpeed;
    public float MoveSpeed {  get { return _moveSpeed; } set {  _moveSpeed = value; } }
    public float MaxSpeed {  get { return _maxSpeed; } }

    [Header("Character Components")]
    private Rigidbody _rigidbody;

    [Header("Another")]
    [SerializeField] private float _doubleSpeedTimer;

    private void Start()
    {
        MoveSpeed = MaxSpeed;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        Vector3 offset = moveDirection * _moveSpeed * Time.deltaTime;

        _rigidbody.MovePosition(_rigidbody.position + offset);

        if (moveDirection != Vector3.zero)
        {
            animatorController.Run();
        }

        else
        {
            animatorController.Idle();
        }
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void IncreaseSpeed()
    {
        StartCoroutine(IncreaseMoveSpeed());
    }

    private IEnumerator IncreaseMoveSpeed()
    {
        if (MoveSpeed < 11f)
        {
            MoveSpeed *= 1.5f;
        }
        yield return new WaitForSeconds(_doubleSpeedTimer);
        MoveSpeed = MaxSpeed;
        StopCoroutine(IncreaseMoveSpeed());
    }
}
