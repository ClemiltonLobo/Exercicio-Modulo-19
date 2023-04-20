using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThornsCollider : MonoBehaviour
{
    public int maxLives = 3;
    public Transform lastCheckpoint;
    public TextMeshProUGUI gameOverText;
    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
        gameOverText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("Player"))
        {            
            if (currentLives > 1)
            {
                currentLives--;
                other.transform.position = lastCheckpoint.position;
            }
            else
            {
                currentLives = 0;
                other.gameObject.SetActive(false);
                gameOverText.gameObject.SetActive(true);
                // Define o texto do objeto de texto "Game Over" para "Game Over"
                //gameOverText.text = "Game Over";
            }
        }
    }
}
