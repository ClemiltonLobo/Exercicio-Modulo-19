using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketController : MonoBehaviour
{
    public GameObject messageText;
    public KeyCode activationKey = KeyCode.E;
    public GameObject keyPrefab;

    private bool isPlayerNear = false;
    private bool hasKey = false;

    void Awake()
    {
        messageText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            messageText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            messageText.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(activationKey))
        {
            if (hasKey)
            {
                // Inicia animação do foguete
                Debug.Log("Foguete ligado!");
            }
            else
            {
                Debug.Log("Colete a chave pra ligar o foguete");
            }
        }
    }

    public void OnKeyCollected()
    {
        hasKey = true;
        Destroy(keyPrefab);
    }
}