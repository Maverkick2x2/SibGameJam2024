using UnityEngine;
using UnityEngine.EventSystems;

public class SoundsPlayer : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource[] audioSource;
    [SerializeField] private AudioSource _clickaudioSource;
    public void PlaySound()
    {
        if (_clickaudioSource != null)
        {
            _clickaudioSource.Play();
        }
    }

    public void PlayStepSound()
    {
        if (audioSource[2] != null)
        {
            audioSource[2].Play();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int rSound = Random.Range(0,audioSource.Length);
        if (audioSource[rSound] != null)
        {
            audioSource[rSound].Play();
        }
    }
}
