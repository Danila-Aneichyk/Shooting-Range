using UnityEngine;

public class AudioService : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip == null)
            return; 
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}