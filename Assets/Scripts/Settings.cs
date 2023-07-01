using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Slider volumeSlider;
    public TMP_Dropdown difficultyDropdown;

    public enum Difficulty
    {
        ROOKIE,PROFESSIONAL,EXPERT
    };

    public const string NAME_PREF = "CONFIG_GLOBAL_NAME";
    public const string VOLUME_PREF = "CONFIG_GLOBAL_VOLUME";
    public const string DIFF_PREF = "CONFIG_GLOBAL_DIFF";

    void Start()
    {
        if (PlayerPrefs.HasKey(NAME_PREF))
        {
            nameInput.text = PlayerPrefs.GetString(NAME_PREF);
        }
        if (PlayerPrefs.HasKey(VOLUME_PREF))
        {
            volumeSlider.value = PlayerPrefs.GetFloat(VOLUME_PREF);
        }
        if (PlayerPrefs.HasKey(DIFF_PREF))
        {
            difficultyDropdown.value = PlayerPrefs.GetInt(DIFF_PREF);
        }
    }

    private void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }
    
    public void Exit()
    {
        PlayerPrefs.SetString(NAME_PREF, nameInput.text);
        PlayerPrefs.SetFloat(VOLUME_PREF, volumeSlider.value);
        PlayerPrefs.SetInt(DIFF_PREF, difficultyDropdown.value);

        SceneManager.LoadScene("MainMenu");
    }
}