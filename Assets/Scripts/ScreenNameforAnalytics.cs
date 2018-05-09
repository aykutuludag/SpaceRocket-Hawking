using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenNameforAnalytics : MonoBehaviour {

    public GoogleAnalyticsV4 googleAnalytics;

    // Use this for initialization
    void Start () {
        Scene scene = SceneManager.GetActiveScene();
        googleAnalytics.LogScreen(scene.name);
    }
}
