using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    public Canvas canvasMain;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText.text = "Score: " + ShipManager.Score;
        PostScoreOnLeaderBoard(ShipManager.Score);// post score on leaderboard!
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goToMain()
    {
        ShipManager.isGameStarted = false;
        ShipManager.isGameOver = false;
        canvasMain.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    public void share()
    {

    }


    public void PostScoreOnLeaderBoard(int myScore)
    {
       /* if (CanvasMain.loginStatus == 1)
        {
            Social.ReportScore(myScore, GPGSIds.leaderboard_top_scores, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Score Guncellendi!!!!!!!!!");

                }
            });
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt("isLogged", 1);
                    Social.ReportScore(myScore, GPGSIds.leaderboard_top_scores, (bool successful) =>
                    {
                        // handle success or failure
                    });
                }
                else
                {
                    PlayerPrefs.SetInt("isLogged", 0);
                    Debug.Log("unsuccessful");
                }
                // handle success or failure
            });
        }*/
    }
}
