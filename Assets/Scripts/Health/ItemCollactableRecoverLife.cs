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
        // Inicie a reprodução do sistema de partículas
        particleSystem.Play();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        HealthBase health = other.gameObject.GetComponent<HealthBase>();
        if (health != null)
        {
            if (other.CompareTag("Player"))
            {
                health.Heal(recoverAmount.value);
                Debug.Log("Você coletou uma cura");

                

                // Destrua o objeto que contém este componente
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
        // Pare a reprodução do sistema de partículas
        particleSystem.Stop();
    }
}