using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Button start;
    public Button settings;
    public Button records;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(StartGame);
        settings.onClick.AddListener(OpenSettings);
        records.onClick.AddListener(OpenRecords);
        quit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        // Load the settings scene
        SceneManager.LoadScene("SettingsScene");
    }

    public void OpenRecords()
    {
        // Load the record scene
        SceneManager.LoadScene("RecordsScene");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
