using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private int nextSceneName;
    [SerializeField] private float _endVideoTimer;

    private void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer vp)
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(_endVideoTimer);

        SceneManager.LoadScene(nextSceneName);
    }
}