using System.Collections;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material _newMaterial;
    [SerializeField] private float _changeColorTimer;

    private void Start()
    {
        if (_newMaterial.color == Color.blue)
        {
            _newMaterial.color = Color.white;
        }
    }

    private void OnEnable()
    {
        SlowingAbility.OnSpeedMoveChangeEvent += ChangeColor;
    }

    private void OnDisable()
    {
        SlowingAbility.OnSpeedMoveChangeEvent -= ChangeColor;
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColoMaterial());
    }

    private IEnumerator ChangeColoMaterial()
    {
        _newMaterial.color = Color.blue;
        yield return new WaitForSeconds(_changeColorTimer);
        _newMaterial.color = Color.white;
    }
}
