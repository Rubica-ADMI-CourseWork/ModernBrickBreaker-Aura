using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip brickXplosionFX;
    public AudioClip largeBrickExplosionFX;

    AudioSource audioSource;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get => instance;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRegularBrickExplosionFX()
    {
        audioSource.PlayOneShot(brickXplosionFX);
    }
    public void PlayLargeExplosionFX()
    {
        audioSource.PlayOneShot(largeBrickExplosionFX);
    }
}
