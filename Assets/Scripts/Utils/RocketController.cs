using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class RocketController : MonoBehaviour
{
    public GameObject messageText;
    public GameObject messageRocketOn;
    public GameObject messageVestKey;
    public KeyCode activationKey = KeyCode.E;
    public GameObject keyPrefab;
    public GameObject playerObject;
    public GameObject windowObject;
    public GameObject insideRocketImage;
    public CinemachineVirtualCamera CameraPlayer;
    public ParticleSystem playRocketSmokeVFX;

    private bool isPlayerNear = false;
    private bool hasKey = false;
    private Animator animator;

    [SerializeField] private Image keyImage;
    [Header("Sounds")]
    public AudioSource audioSource;
    public Transform soundObject;

    void Awake()
    {
        messageText.SetActive(false);
        messageRocketOn.SetActive(false);
        messageVestKey.SetActive(false);
        keyImage.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
        if (soundObject != null) soundObject.SetParent(null);
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
            messageRocketOn.SetActive(false);
            messageVestKey.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(activationKey))
        {
            if (hasKey)
            {                
                messageText.SetActive(false);
                messageVestKey.SetActive(false);                
                keyImage.gameObject.SetActive(false);
                
                insideRocketImage.SetActive(true);
                
                playerObject.SetActive(false);
                CameraPlayer.gameObject.SetActive(false);
                
                
                PlayRocketSmokeVFX();
                if (audioSource != null) audioSource.Play();
                animator.SetTrigger("Launch");                
            }
            else
            {
                messageText.SetActive(false);
                messageVestKey.gameObject.SetActive(true);
            }
        }
    }

    private void PlayRocketSmokeVFX()
    {
        if (playRocketSmokeVFX != null) playRocketSmokeVFX.Play();
    }

    public void OnAnimationEnd()
    {
        if (audioSource != null) audioSource.Stop();
    }

    public void OnKeyCollected()
    {
        hasKey = true;
        Destroy(keyPrefab);
        keyImage.gameObject.SetActive(true);
    }
}