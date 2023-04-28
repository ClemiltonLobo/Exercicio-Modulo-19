using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public GameObject player;
    public float playerActivationTime = 2.0f;
    public float cameraAnimationTime = 2.0f;

    private void Start()
    {
        // Desativa o jogador no início do jogo
        player.SetActive(false);

        // Desativa o componente Animator da câmera
        Camera.main.GetComponent<Animator>().enabled = false;


        // Inicia a corrotina para ativar o jogador depois de um tempo
        StartCoroutine(ActivatePlayer());
        
    }

    IEnumerator ActivatePlayer()
    {
        // Espera o tempo definido para ativar o jogador
        yield return new WaitForSeconds(playerActivationTime);

        // Ativa o jogador
        player.SetActive(true);

        // Aguarda a animação do jogador terminar
        Animator playerAnimator = player.GetComponent<Animator>();
        yield return new WaitForSeconds(playerAnimator.GetCurrentAnimatorStateInfo(0).length);

        // Ativa o componente Animator da câmera
        Camera.main.GetComponent<Animator>().enabled = true;

        // Desativa o componente Animator da câmera
        yield return new WaitForSeconds(cameraAnimationTime);
        Camera.main.GetComponent<Animator>().enabled = false;
    }
}