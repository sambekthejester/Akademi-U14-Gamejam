using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _slideSound;
    [SerializeField] private AudioClip _cardArrivalSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySlideSound()
    {
        _audioSource.PlayOneShot(_slideSound);
    }

    public void PlayCardArrivalSound()
    {
        _audioSource.PlayOneShot(_cardArrivalSound);
    }
}

