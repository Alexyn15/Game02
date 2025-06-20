using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public AudioClip JumpSound;
    public AudioClip WinSound;
    public AudioClip CollectSound;

    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void PlayJumpSound()
    {

        audioSource.PlayOneShot(JumpSound,audioSource.volume );
        
    }
    public void PlayWinSound()
    {
        audioSource.PlayOneShot(WinSound);
    }
    public void PlayCollectSound()
    {
        audioSource.PlayOneShot(CollectSound);
    }
    public void SetSFXVolume(float volume)
    {

        audioSource.volume = volume;
     
    }
}
