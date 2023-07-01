using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserLifeTime = 5f;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate = 0.2f;
    private bool isFiring = true;
    Coroutine firingCoroutine;

    private AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Update()
    {
        if ( Input.GetMouseButton(0) )
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
        Fire();
    }

    private void Fire()
    {
        if ( isFiring && firingCoroutine == null )
        {
            firingCoroutine = StartCoroutine(FireCoroutine());
        }
        else if ( !isFiring && firingCoroutine != null )
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireCoroutine()
    {
        while ( true )
        {
            GameObject instance = Instantiate( laserPrefab, transform.position, Quaternion.identity);
            Destroy( instance, laserLifeTime);
            audioPlayer.PlayShootingClipPlayer();
            yield return new WaitForSeconds( fireRate );
        }
    }

    public void ChangeDamage( float value )
    {
        damage *= value;
    }
    public float GetDamage()
    {
        return damage;
    }

    public void ChangeFireRate( float value )
    {
        fireRate += value;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
}
