using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThornsCollider : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;    

    private void Start()
    {        
        gameOverText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("Player"))
        {
            {
                gameOverText.gameObject.SetActive(true);
                other.gameObject.SetActive(false);
            }
        }
    }
}
