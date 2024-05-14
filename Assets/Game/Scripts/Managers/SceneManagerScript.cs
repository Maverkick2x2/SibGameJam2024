using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private void OnEnable()
    {
        Health.OnDied += StopGame;
        Score.OnSceneLoadedEvent += LoadSceneByIndex;
    }

    private void OnDisable()
    {
        Health.OnDied -= StopGame; 
        Score.OnSceneLoadedEvent -= LoadSceneByIndex;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeGame();
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
