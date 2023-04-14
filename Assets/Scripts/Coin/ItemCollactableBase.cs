using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public new ParticleSystem particleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;
    public Transform soundObject;

    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
        if (soundObject != null) soundObject.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
    protected virtual void Collect()
        {
            gameObject.SetActive(false);
            OnCollect();
        }
    protected virtual void OnCollect()
        {
        if(particleSystem != null) particleSystem.Play();
        if(audioSource != null) audioSource.Play();
        if (soundObject != null) soundObject.SetParent(null);
    }

    private void OnDisable()
    {
        if (particleSystem != null) particleSystem.Stop();
    }
}
