using UnityEngine;

public class AudioSettingsLoader : MonoBehaviour
{
    public const string VOLUME_PREF = "CONFIG_GLOBAL_VOLUME";
    private void Start()
    {
        if (PlayerPrefs.HasKey(VOLUME_PREF))
        {
            AudioListener.volume = PlayerPrefs.GetFloat(VOLUME_PREF);
        }
    }
}