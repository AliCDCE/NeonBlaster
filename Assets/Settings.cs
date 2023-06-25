using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public TMPro.TMP_InputField nameInput;
    public Slider volumeSlider;
    public TMPro.TMP_Dropdown difficultyDropdown;
    public Button exitButton;

    public static string playerName = "";
    public static float volume = 1;
    public static Difficulty difficulty = Difficulty.ROOKIE;

    void Start()
    {
        nameInput.text = playerName;
        volumeSlider.value = volume;
        difficultyDropdown.value = (int)difficulty;
        exitButton.onClick.AddListener(Exit);
    }
    public enum Difficulty
    {
        ROOKIE,PROFESSIONAL,EXPERT
    };
    

    void Exit()
    {
        playerName = nameInput.text;
        volume = volumeSlider.value;
        difficulty = (Difficulty)difficultyDropdown.value;
        SceneManager.LoadScene("MenuScene");
    }
}
