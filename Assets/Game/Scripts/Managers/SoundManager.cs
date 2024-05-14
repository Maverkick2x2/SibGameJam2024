using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundsCollection;

    [SerializeField] private AudioSource[] _audio;

    private void Start()
    {
        for (int i = 0; i < _audio.Length; i++)
        {
            if (transform.childCount > 0)
            {
                _audio[i] = transform.GetChild(i).GetComponent<AudioSource>(); 
                
                float volume = PlayerPrefs.GetFloat("Volume");

                if (_audio[i] != null)
                {
                    _audio[i].volume = volume;
                }
            }
        }
    }

    public void ChangeSound(float volume)
    {
        for (int i = 0; i < _audio.Length; i++)
        {
            _audio[i].volume = volume;
            PlayerPrefs.SetFloat("Volume", volume);
        } 
    }
}
