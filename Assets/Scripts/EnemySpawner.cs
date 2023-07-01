using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float[] chance = { 1f , 0f , 0f };
    private float min_spawnTime = 2;
    private float max_spawnTime = 4;

    void Start()
    {
        StartCoroutine(SpawnEnemyCo());
        min_spawnTime = DifficultyManager.min_spawnTime;
        max_spawnTime = DifficultyManager.max_spawnTime;
    }

    private IEnumerator SpawnEnemyCo()
    {
        while ( true )
        {
            yield return new WaitForSeconds( Random.Range( min_spawnTime, max_spawnTime) );
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 targetPos = new Vector2( Random.Range(-2,2), 6);
        Instantiate( enemies[PickEnemy()], targetPos, Quaternion.identity);
    }

    private int PickEnemy()
    {
        int index = 0;
        float chanceSum=0;
        for (int i = 0; i < chance.Length ; i++)
            chanceSum += chance[i];

        float r = Random.Range( 0, chanceSum);
        while (r > 0)
        {
            r -= chance[index];
            index++;
        }
        index--;
        return index;
    }

    public void ModifyChance( float[] newChance )
    {
        chance = newChance;
    }
}