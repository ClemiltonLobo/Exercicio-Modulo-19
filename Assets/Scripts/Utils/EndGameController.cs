using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class EndGameController : MonoBehaviour
{
    public GameObject player;
    public GameObject setOfUncles;
    public GameObject enemy;
    public Animator main_Cam;
    public float playerActivationTime = 2.0f;
    public float cameraAnimationTime = 2.0f;
    public ParticleSystem enemyExplosion;
    public GameObject prefabToDisable;
    public Animator artifactAnimator;
    public Animator rocket;
    public ParticleSystem startRocket2;
    public TextMeshProUGUI textMissaoCuprida;
    public GameObject voltarMenuPrincipal;

    private void Start()
    {
        // Desativa o componente Animator da câmera
        Camera.main.GetComponent<Animator>().enabled = false;

        // Desativa o objeto que contém a animação do player
        player.GetComponent<Animator>().enabled = false;

        // Desativa a partícula
        var emission = enemyExplosion.emission;
        emission.enabled = true;


        // Inicia a corrotina para ativar o jogador depois de um tempo
        StartCoroutine(ActivatePlayer());
    }

    IEnumerator ActivatePlayer()
    {
        // Espera o tempo definido para ativar o jogador
        yield return new WaitForSeconds(playerActivationTime);

        // Ativa o jogador
        player.SetActive(true);

        // Aguarda a animação do jogador terminar, desativa player
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(playerActivationTime);

        // Ativa o componente Animator da câmera
        Camera.main.GetComponent<Animator>().enabled = true;

        // Desativa o componente Animator da câmera
        yield return new WaitForSeconds(cameraAnimationTime);
        Camera.main.GetComponent<Animator>().enabled = false;

        // Ativa o enemy e desativa o prefabToDisable
        enemy.SetActive(true);
        prefabToDisable.SetActive(false);

        // Ativa a partícula
        enemyExplosion.Play();
        yield return new WaitForSeconds(2f);
        setOfUncles.SetActive(false);
        player.GetComponent<Animator>().enabled = true;
        artifactAnimator.gameObject.SetActive(true);
        artifactAnimator.Play("Anim_CatchingArtifact");
        Camera.main.GetComponent<Animator>().enabled = true;
        main_Cam.gameObject.SetActive(true);
        main_Cam.Play("Anim_CamArtfact");
        textMissaoCuprida.gameObject.SetActive(true);
        yield return new WaitForSeconds(8f);
        rocket.GetComponent<Animator>().enabled = true;
        rocket.Play("Rocket_FlyToEarth");
        voltarMenuPrincipal.gameObject.SetActive(true);
    }
}