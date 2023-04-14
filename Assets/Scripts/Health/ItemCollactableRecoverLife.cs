using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ebac.Core.Singleton;

public class ItemCollactableRecoverLife :ItemCollactableBase
{
    public SOFloat recoverAmount;

    private void Awake()
    {        
        particleSystem.Play();
        if (soundObject != null) soundObject.SetParent(null);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthBase health = other.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            if (other.CompareTag("Player"))
            {
                if (audioSource != null) audioSource.Play();
                if (soundObject != null) soundObject.SetParent(null);
                health.Heal(recoverAmount.value);
                Debug.Log("Você coletou uma cura");                               
                Destroy(gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                // Não faz nada, já que inimigos não podem coletar cura
            }
        }
    }

    private void OnDisable()
    {        
        particleSystem.Stop();
    }
}