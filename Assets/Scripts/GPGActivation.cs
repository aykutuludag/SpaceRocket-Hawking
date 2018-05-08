using GooglePlayGames;
using UnityEngine;

public class GPGActivation : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        login();
    }

    public static void login()
    {
        // authenticate user:
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                PlayerPrefs.SetInt("isLogged", 1);
            }
            else
            {
                PlayerPrefs.SetInt("isLogged", 0);
            }
        });
    }
}
