using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    static MenuMusicPlayer instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if ( instance != null )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}