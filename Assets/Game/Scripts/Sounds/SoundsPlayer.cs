using UnityEngine;
using UnityEngine.EventSystems;

public class SoundsPlayer : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource[] _dedVoiceAudioSource;
    [SerializeField] private AudioSource _anotherAudioSource;
    [SerializeField] private AudioSource _stepSoundSource;
    [SerializeField] private AudioSource _clickSoundSource;

    public void PlayClickSoundSound()
    {
        if (_clickSoundSource != null)
        {
            _clickSoundSource.Play();
        }
    }

    public void PlayStepSound()
    {
        if (_stepSoundSource != null)
        {
            _stepSoundSource.Play();
        }
    }

    public void PlayAnotherSound()
    {
        if (_anotherAudioSource != null)
        {
            _anotherAudioSource.Play();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int rSound = Random.Range(0, _dedVoiceAudioSource.Length);
        if (_dedVoiceAudioSource[rSound] != null)
        {
            _dedVoiceAudioSource[rSound].Play();
        }
    }
}
