using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private int diff = 0;
    [SerializeField] private Rigidbody2D enemy;
    public static float min_spawnTime = 2;
    public static float max_spawnTime = 4;
    public const string DIFF_PREF = "CONFIG_GLOBAL_DIFF";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(DIFF_PREF))
        {
            diff = PlayerPrefs.GetInt(DIFF_PREF);
        }
        Manage();
    }

    public void Manage()
    {
        switch (diff)
        {
            case 0 :
                enemy.gravityScale = 0.5f; 
                min_spawnTime = 2;
                max_spawnTime = 4;
                break;
            case 1 :
                enemy.gravityScale = 0.75f; 
                min_spawnTime = 1.5f;
                max_spawnTime = 3;
                break;
            case 2 :
                enemy.gravityScale = 1f; 
                min_spawnTime = 1;
                max_spawnTime = 2;
                break;
        }
    }
}