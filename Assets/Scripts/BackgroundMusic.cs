using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
    }


    void Update()
    {

    }


    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
