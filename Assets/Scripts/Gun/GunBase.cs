using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public Transform playerSideReference;
    public AudioSource audioSource;
    //public Transform soundObject;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        //if (soundObject != null) soundObject.SetParent(null);
        var player = GameObject.FindGameObjectWithTag("Player");        
        playerSideReference = player.GetComponent<Player>().playerTransform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (audioSource != null) audioSource.Play();
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
