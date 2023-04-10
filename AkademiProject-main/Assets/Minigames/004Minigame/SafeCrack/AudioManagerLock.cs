using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerLock : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySFX(AudioClip sfx, float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.clip = sfx;
        audioSource.Play();
    }

    public void StopSFX()
    {
        audioSource.Stop();
    }
}
