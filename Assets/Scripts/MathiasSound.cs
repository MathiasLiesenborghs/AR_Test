using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MathiasSound : MonoBehaviour
{
    public AudioClip SoundSpawn;
    public AudioClip SoundDestroy;
    private AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        if (SoundSpawn != null)
        {
            AudioSource.PlayOneShot(SoundSpawn);
        }
    }

    void OnDestroy()
    {

    }

    internal void PlayDestroySound()
    {
        AudioSource?.PlayOneShot(SoundDestroy);
    }
}
