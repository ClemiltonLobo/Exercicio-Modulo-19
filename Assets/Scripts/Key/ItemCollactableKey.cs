using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ItemCollactableKey : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource audioSource;
    public Transform soundObject;

    private void Awake()
    {
        if (soundObject != null) soundObject.SetParent(null);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null) audioSource.Play();
            if (soundObject != null) soundObject.SetParent(null);
            RocketController rocket = FindObjectOfType<RocketController>();
            rocket.OnKeyCollected();
            Destroy(gameObject);
        }
    }
}
