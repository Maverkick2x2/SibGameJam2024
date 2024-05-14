using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _controlleAndInterfacerCanvasPanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _winPanel;

    [Header("Another")]
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private SceneManagerScript _sceneManagerScript;

    private bool _isPlaying = true;

    private void OnEnable()
    {
        Health.OnDied += ShowScorePanel;
    }

    private void OnDisable()
    {
        Health.OnDied -= ShowScorePanel;
    }

    private void ShowScorePanel()
    {
        _controlleAndInterfacerCanvasPanel.SetActive(false);
        _scorePanel.SetActive(true);
        _scoreView.ShowTotalScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (_isPlaying)
        {
            _pausePanel.SetActive(true);
            _controlleAndInterfacerCanvasPanel.SetActive(false);
            _isPlaying = false;
            _sceneManagerScript.StopGame();
        }
        else
        {
            _controlleAndInterfacerCanvasPanel.SetActive(true);
            _pausePanel.SetActive(false);
            _isPlaying = true;
            _sceneManagerScript.ResumeGame();
        }
    }
}
