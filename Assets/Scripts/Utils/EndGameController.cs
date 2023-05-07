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
        Camera.main.GetComponent<Animator>().enabled = false;
        
        player.GetComponent<Animator>().enabled = false;
        
        var emission = enemyExplosion.emission;
        emission.enabled = true;
        
        StartCoroutine(ActivatePlayer());
    }

    IEnumerator ActivatePlayer()
    {        
        yield return new WaitForSeconds(playerActivationTime);
        
        player.SetActive(true);
        
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(playerActivationTime);
        
        Camera.main.GetComponent<Animator>().enabled = true;
        
        yield return new WaitForSeconds(cameraAnimationTime);
        Camera.main.GetComponent<Animator>().enabled = false;
        
        enemy.SetActive(true);
        prefabToDisable.SetActive(false);
        
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