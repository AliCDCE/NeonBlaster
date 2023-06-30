using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;

    void Start()
    {
        StartCoroutine(SpawnPowerUpCo());
    }

    private IEnumerator SpawnPowerUpCo()
    {
        while ( true )
        {
            yield return new WaitForSeconds( Random.Range(20,30) );
            SpawnPowerUp();
        }
    }
    
    private void SpawnPowerUp()
    {
        Vector2 targetPos = new Vector2( Random.Range(-2,2), 6);
        Instantiate( powerUps[ Random.Range(0,powerUps.Length) ], targetPos, Quaternion.identity);
    }
}