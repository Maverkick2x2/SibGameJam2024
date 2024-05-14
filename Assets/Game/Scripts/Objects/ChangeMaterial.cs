using System.Collections;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material newMaterial;

    private Renderer _renderer;
    private Material _material;

    private void Start()
    {
        // ������� ����� ��������� ��� ���������
        _material = new Material(newMaterial);

        // �������� ��������� Renderer � �������
        _renderer = gameObject.AddComponent<Renderer>();

        // ������������� ����� �������� ��� �������
        _renderer.material = _material;
    }

    public void ChangeColor()
    {
        StartCoroutine(ChangeColoMaterial());
    }

    private IEnumerator ChangeColoMaterial()
    {
        _renderer.material.color = Color.blue;
        yield return new WaitForSeconds(8f);
        _renderer.material.color = Color.white;
    }
}
