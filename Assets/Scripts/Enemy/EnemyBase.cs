using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerkill = "Kill";
    public HealthBase healthBase;
    public float timeToDestroy = 1f;

    [Header("Sounds")]
    public AudioSource audioSource;
    public Transform soundObject;


    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.onKill += onEnemyKill;
            if (soundObject != null) soundObject.SetParent(null);
        }
    }

    private void onEnemyKill()
    {
        healthBase.onKill -= onEnemyKill;
        PlaykillAnimation();
        Destroy(gameObject, timeToDestroy);
        if (audioSource != null) audioSource.Play();
        if (soundObject != null) soundObject.SetParent(null);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlaykillAnimation()
    {
        animator.SetTrigger(triggerkill);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
