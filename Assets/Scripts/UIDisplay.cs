using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper scoreKeeper;

    private void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
}