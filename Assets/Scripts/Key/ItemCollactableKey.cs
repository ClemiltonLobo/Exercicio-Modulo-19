using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ItemCollactableKey : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RocketController rocket = FindObjectOfType<RocketController>();
            rocket.OnKeyCollected();
            Destroy(gameObject);
        }
    }
}
