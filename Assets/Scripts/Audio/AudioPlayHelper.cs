using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public AudioSource audioSource;

    private void Update()
    {
        if (audioSource != null)
        {
            Play();
        }
    }
    public void Play()
    {
        audioSource.Play();
    }
}
