using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;
    private EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore( int value )
    {
        score += value;
        Mathf.Clamp( score, 0, int.MaxValue);
        ManageDifficulty();
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void ManageDifficulty()
    {
        float[] tempChance;
        if ( 0 <= score && score < 20 ) {       tempChance = new float[] { 1f, 0f, 0f }; }
        else if ( 20 <= score && score < 40 ) { tempChance = new float[] { 1f, 0.2f, 0f }; }
        else if ( 40 <= score && score < 60 ) { tempChance = new float[] { 1f, 0.3f, 0.1f }; }
        else if ( 60 <= score && score < 80 ) { tempChance = new float[] { 1f, 0.5f, 0.2f }; }
        else {                                  tempChance = new float[] { 1f, 0.7f, 0.3f }; }
        enemySpawner.ModifyChance( tempChance );
    }
}
