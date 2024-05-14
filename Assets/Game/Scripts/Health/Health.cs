using System;
using UnityEngine;
public class Health : MonoBehaviour, IDamageable
{
    [Header("Health stats")]
    [SerializeField] private float _maxHealth = 100;
    [SerializeField] private AnimatorController _animator;
    public float CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    public event Action<float> HealthChanged;
    public IntEvent Hit = new IntEvent();
    public static event Action OnDied;

    private float _currentHealth;
    private float bugTimer = 2f;
    private float flyBugTimer = 2f;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Bug")
        {
            HandleBugCollision(2, ref bugTimer);
        }
        if (collision.collider.tag == "FlyingBug")
        {
            HandleBugCollision(3, ref flyBugTimer);
        }
    }

    private void HandleBugCollision(int damageAmount, ref float bugTimer)
    {
        bugTimer -= Time.deltaTime;
        if (bugTimer <= 0)
        {
            _animator.PotatoHit();
            ApplyDamage(damageAmount);
            bugTimer = 2f;
        }
    }


    public void ApplyDamage(int value)
    {
        if (value >= 0)
        {
            _currentHealth -= value;
            Hit.Invoke(value);

            if (_currentHealth <= 0)
            {
                Death();
            }
            else
            {
                float _currentHealthAtPercentage = (float)_currentHealth / _maxHealth;
                HealthChanged?.Invoke(_currentHealthAtPercentage);
            }
        }
        else
        {
            Debug.Log("Отрицательное значение урона");
        }
    }

    public void AddHealth(float health)
    {
        _currentHealth += health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        float _currentHealthAtPercentage = _currentHealth / _maxHealth;
        HealthChanged?.Invoke(_currentHealthAtPercentage);
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        OnDied?.Invoke();
        Debug.Log("You are dead");
    }

}
