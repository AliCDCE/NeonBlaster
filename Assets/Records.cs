using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Records : MonoBehaviour
{
    public Button returnButton;
    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(returnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void returnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
