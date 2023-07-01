using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class LeaderboardUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI leaderboardText;
    private LeaderboardClient leaderboardClient;

    private const int TOP_SCORES_COUNT = 10;

    private void Awake()
    {
        leaderboardClient = FindObjectOfType<LeaderboardClient>();
    }

    void Start()
    {
        // leaderboardClient.GetTopScores(TOP_SCORES_COUNT, OnTopScoresRetrieved);
        // leaderboardClient.GetTopScores(TOP_SCORES_COUNT);
        StartCoroutine(leaderboardClient.GetRequest(10));
    }

    private void OnTopScoresRetrieved(Dictionary<string, int> scores)
    {
        string leaderboardString = "Top Scores:\n";

        foreach (KeyValuePair<string, int> score in scores)
        {
            leaderboardString += score.Key + ": " + score.Value + "\n";
        }

        leaderboardText.text = leaderboardString;
    }
}