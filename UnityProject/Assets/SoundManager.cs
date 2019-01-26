using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip creepingSpider;
    public AudioClip squishSpider;

    public AudioSource audiosource;

    private void Awake()
    {
        audiosource.GetComponent<AudioSource>();
    }

    public void playSound(AudioSource audioSource, string clip, float delay = 0f)
    {
        switch(clip)
        {
            case "creepingSpider":
                StartCoroutine(playSoundWithDelay(audioSource, creepingSpider, delay));
                break;
            case "squishSpider":
                StartCoroutine(playSoundWithDelay(audioSource, squishSpider, delay));
                break;
            default:
                break;
        }
    }

    IEnumerator playSoundWithDelay(AudioSource audioSource, AudioClip clip, float delay, float volume = 1)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip);
        audioSource.volume = volume;
    }
}
