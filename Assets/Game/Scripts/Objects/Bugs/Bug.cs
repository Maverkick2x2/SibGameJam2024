using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private int _maxReward;
    [SerializeField] private int _minReward;

    public IntEvent Hit = new IntEvent();
    public IntEvent Fight = new IntEvent();

    private int _reward;

    public int Reward { get { return _reward; } }

    private void Start()
    {
        _reward = Random.Range(_minReward, _maxReward);
    }
}
