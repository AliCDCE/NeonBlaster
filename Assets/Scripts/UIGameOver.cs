using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI recordText;
    [SerializeField] private GameObject newRecordText;
    ScoreKeeper scoreKeeper;
    private LeaderboardClient leaderboardClient;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        leaderboardClient = FindObjectOfType<LeaderboardClient>();
    }

    void Start()
    {
        int score = scoreKeeper.GetScore();
        scoreText.text = "you scored : " + score;
        if ( score > scoreKeeper.GetRecord() )
        {
            scoreKeeper.SetRecord(score);
            newRecordText.SetActive(true);
        }
        recordText.text = "your record : " + scoreKeeper.GetRecord();
        
        // leaderboardClient.AddScore( Settings.playerName, scoreKeeper.GetScore(), OnScoreUploaded);
        // leaderboardClient.AddScore( Settings.playerName, scoreKeeper.GetScore());
        // StartCoroutine(leaderboardClient.POSTRequest( Settings.playerName, scoreKeeper.GetScore() ));
    }

    // private void OnScoreUploaded()
    // {
    //     Debug.Log("uploading score was successful!");
    // }
}