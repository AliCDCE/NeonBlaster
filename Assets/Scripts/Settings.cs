using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Slider volumeSlider;
    public TMP_Dropdown difficultyDropdown;

    public static string playerName = "";
    public static float volume = 1;
    public static Difficulty difficulty = Difficulty.ROOKIE;
    public enum Difficulty
    {
        ROOKIE,PROFESSIONAL,EXPERT
    };

    void Start()
    {
        nameInput.text = playerName;
        volumeSlider.value = volume;
        difficultyDropdown.value = (int)difficulty;
    }
    
    public void Exit()
    {
        playerName = nameInput.text;
        volume = volumeSlider.value;
        difficulty = (Difficulty)difficultyDropdown.value;
        SceneManager.LoadScene("MainMenu");
    }
}