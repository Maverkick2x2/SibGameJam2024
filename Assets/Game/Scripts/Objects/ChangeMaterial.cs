using System.Collections;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material newMaterial;

    private Renderer _renderer;
    private Material _material;

    private void Start()
    {
        // Создаем копию материала для изменения
        _material = new Material(newMaterial);

        // Получаем компонент Renderer у префаба
        _renderer = gameObject.AddComponent<Renderer>();

        // Устанавливаем новый материал для префаба
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
