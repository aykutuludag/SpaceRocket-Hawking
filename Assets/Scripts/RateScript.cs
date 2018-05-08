using UnityEngine;

public class RateScript : MonoBehaviour
{
    public GameObject ratePopup;
    public string googlePlayUrl;
    public string appStoreUrl;
    public static int openCount;
    int isUserWant;

    // Use this for initialization
    void Start()
    {
        openCount = PlayerPrefs.GetInt("RateCount", 0);
        openCount++;
        PlayerPrefs.SetInt("RateCount", openCount);

        isUserWant = PlayerPrefs.GetInt("isUserWant", 1);

        if (openCount >= 5 && isUserWant == 1)
        {
            ratePopup.SetActive(true);
        }
        else
        {
            ratePopup.SetActive(false);
        }
    }

    public void answerYes()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL(googlePlayUrl);
        }
        else
        {
			Application.OpenURL(appStoreUrl);
        }

        isUserWant = 0;
        PlayerPrefs.SetInt("isUserWant", isUserWant);
        ratePopup.SetActive(false);
    }

    public void answerLater()
    {
        openCount = 0;
        PlayerPrefs.SetInt("RateCount", openCount);
        ratePopup.SetActive(false);
    }

    public void answerNo()
    {
        isUserWant = 0;
        PlayerPrefs.SetInt("isUserWant", isUserWant);
        ratePopup.SetActive(false);
    }
}
