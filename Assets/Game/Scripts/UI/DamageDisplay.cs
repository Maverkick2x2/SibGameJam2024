using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField] private TextMesh _textPrefab;

    [SerializeField] private Transform _spawnPoint;

    private float _offset;
    [SerializeField] private float _minOffset;
    [SerializeField] private float _maxOffset;

    public void SetDamage(int value)
    {
        _offset = Random.Range(_minOffset, _maxOffset);
        TextMesh _text = Instantiate(_textPrefab, new Vector3(_spawnPoint.position.x + _offset, _spawnPoint.position.y, _spawnPoint.position.z), Quaternion.identity);
        _text.text = value.ToString();
    }
}
