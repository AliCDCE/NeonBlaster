using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public void StartGame()
    {
        scoreKeeper.ResetScore();
        var tempMusic = FindObjectOfType<MenuMusicPlayer>();
        if ( tempMusic != null )
        {
            Destroy(tempMusic.gameObject);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenGameOver()
    {
        StartCoroutine(WaitAndOpen( "GameOver", 2f));
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    private IEnumerator WaitAndOpen( string sceneName, float delay)
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds( delay );
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

}