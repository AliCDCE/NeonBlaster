using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_pet : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserLifeTime = 5f;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate = 0.2f;
    private Coroutine firingCoroutine;

    void Start()
    {
        firingCoroutine = StartCoroutine(FireCoroutine());
    }

    IEnumerator FireCoroutine()
    {
        while ( true )
        {
            GameObject instance = Instantiate( laserPrefab, transform.position, Quaternion.identity);
            Destroy( instance, laserLifeTime);
            yield return new WaitForSeconds( fireRate );
        }
    }

    public void Disable()
    {
        StopCoroutine(firingCoroutine);
        gameObject.GetComponent<Pet>().go = false;
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
