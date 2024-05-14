using System.Collections;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void SetAnimationParameter(string paramName, bool value)
    {
        _animator.SetBool(paramName, value);
    }

    public void SetAnimationState(string activeParam, params string[] inactiveParams)
    {
        foreach (string param in inactiveParams)
        {
            SetAnimationParameter(param, false);
        }

        SetAnimationParameter(activeParam, true);
    }

    public void Run()
    {
        SetAnimationState("Run", "Idle", "DedDownAttack", "DedUpAttack");
    }

    public void Idle()
    {
        SetAnimationState("Idle", "Run", "DedDownAttack", "DedUpAttack");
    }

    public void DedDownAttack()
    {
        SetAnimationState("DedDownAttack", "Run", "Idle", "DedUpAttack");
    }

    public void DedUpAttack()
    {
        SetAnimationState("DedUpAttack", "Run", "Idle", "DedDownAttack");
    }

    public void PotatoHit()
    {
        StartCoroutine(HitAnim("PotatoHit", 1f));
    }

    public void BugHit()
    {
        SetAnimationParameter("BugHit", true);
    }

    public void BugFly()
    {
        SetAnimationParameter("BugHit", false);
    }

    private IEnumerator HitAnim(string paramName, float duration)
    {
        SetAnimationParameter(paramName, true);
        yield return new WaitForSeconds(duration);
        SetAnimationParameter(paramName, false);
    }
}
