using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine;
using System.Collections;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int nextSceneName;

    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer vp)
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1); //Делаем задержку, чтобы видео успело проиграть до конца

        SceneManager.LoadScene(nextSceneName);
    }
}