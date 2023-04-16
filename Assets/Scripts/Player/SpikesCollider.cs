using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (other.CompareTag("Player"))
        {
            // Desativa o objeto do jogador
            other.gameObject.SetActive(false);
        }
    }    
}
