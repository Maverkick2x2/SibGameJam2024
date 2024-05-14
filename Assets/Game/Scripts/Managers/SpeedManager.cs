using System.Collections;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private RandomMove[] _randomMoveObjects;

    private float _speedValue;
    private float _maxSpeedValue;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
        _speedValue = 1f;
        _maxSpeedValue = 5f;
    }

    private IEnumerator IncreaseSpeed()
    {
        for (int i = 0; i < 5000; i++)
        {
            yield return new WaitForSeconds(4f);
            _randomMoveObjects = FindObjectsOfType<RandomMove>();

            for (int j = 0; j < _randomMoveObjects.Length; j++)
            {
                if (_randomMoveObjects[j].Speed < _maxSpeedValue)
                {
                    _randomMoveObjects[j].Speed *= _speedValue;
                }

                else
                {
                    _randomMoveObjects[j].Speed = _maxSpeedValue;
                }

                Debug.Log(_randomMoveObjects[j].Speed);
            }

            if (_speedValue < 2f)
            {
                _speedValue += 0.01f;
            }
        }
    }
}
