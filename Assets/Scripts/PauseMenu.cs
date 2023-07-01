using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private Slider volumeSlider;
    public const string VOLUME_PREF = "CONFIG_GLOBAL_VOLUME";

    private void Start()
    {
        if (PlayerPrefs.HasKey(VOLUME_PREF))
        {
            volumeSlider.value = PlayerPrefs.GetFloat(VOLUME_PREF);
        }
    }

    private void Update()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PlayerPrefs.SetFloat(VOLUME_PREF, volumeSlider.value);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}