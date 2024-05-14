using UnityEngine;
using UnityEngine.EventSystems;

public class SoundsPlayer : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource[] audioSource;
    public void PlaySound()
    {
        if (audioSource[0] != null)
        {
            audioSource[0].Play();
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
        if (audioSource[1] != null)
        {
            audioSource[1].Play();
        }
    }
}
