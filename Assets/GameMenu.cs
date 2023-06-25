using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Button pause;
    public Canvas gameMenu;
    public Button resume;
    public Button restart;
    public Button menu;
    
    // Start is called before the first frame update
    void Start()
    {
        pause.onClick.AddListener(Pause);
        resume.onClick.AddListener(Resume);
        restart.onClick.AddListener(Restart);
        menu.onClick.AddListener(Menu);
    }

    void showMenu()
    {
        gameMenu.gameObject.SetActive(true);
        pause.gameObject.SetActive(false);
    }

    void hideMenu()
    {
        gameMenu.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }

    void Pause()
    {
        showMenu();
        //Pause the game
    }

    void Resume()
    {
        hideMenu();
        //Resume the game
    }

    void Restart()
    {
        hideMenu();
        //Restart the game
    }

    void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
