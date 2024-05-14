using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] SoundsCollection;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventManager.OnAudioClipUpdateEvent += PlaySound;
    }

    private void OnDisable()
    {
        EventManager.OnAudioClipUpdateEvent -= PlaySound;
    }

    private void PlaySound()
    {
        _audioSource.clip = SoundsCollection[0];
        _audioSource.Play();
    }


}
