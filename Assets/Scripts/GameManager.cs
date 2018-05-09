using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public enum GameState { Menu, PlayingFight, PlayingHyperSpace, PlayingBonus, PlayinPaused, GameOver }
    public GameState gamestate;
    public static GameManager gm;

    public Player player;
    public Canvas mainMenu, gamePause, gameOver, canvasSettings, canvasStore, inGameUI;
    public static int score;

    public static bool isGameStarted;
    public static bool paused;
    public static bool isGameOver;


    [Header("Map")]
    public Transform center;
    public Transform path;
    public Transform player_shadow;

    public float centerAngularSpeed;
    public float centerHorizontalSpeed;
    public float pathRad;
    public float shipTurnRate;
    public static float shipRad = 2.5f;
    [Header("Score")]
    public static int currentScore;

    public int skor;


    void Awake()
    {
        gm = this;
    }
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        gamestate = GameState.Menu;
    }

    public void GameStarter()
    {
        gamestate = GameState.PlayingFight;
        score = 0;
        mainMenu.gameObject.SetActive(false);
        //mainMenu.enabled = false;
        inGameUI.gameObject.SetActive(true);
        //inGameUI.enabled = true;
        //gm.enabled=false;
        player.startingHealth = player.maxHealth;
        path.transform.localPosition = center.transform.position + new Vector3(pathRad, 0, 0);
        player_shadow.transform.localPosition = new Vector3(0, -shipRad, 0);

        Debug.Log("GameStarter", gameObject);
        player.GameStarted();
        /*
		 Instantiate(startEnemies,Vector3.zero,Quaternion.identity);
		diverspawner.enabled = true;
		diverspawner.NextWave();
		stationaryspawner.enabled = true;
		stationaryspawner.NextWave();
		chaserspawner.enabled = true;
		chaserspawner.NextWave();
		combo = 0;
		ui.SetActive(true);
		gameMainMenu.SetActive(false);
		gameOverMenu.SetActive(false);
		comboStoper = false;
		Time.timeScale = 1;
		test = !test;
		*/


    }
    public void Again()
    {
        GameOver();
        GameStarter();
    }
    public void GameOver()
    {

    }
    void Update()
    {

        switch (gamestate)
        {
            case GameState.Menu:
                ///0'da yapilacaklar

                break;
            case GameState.PlayingFight:
                player.chase = true;
                center.transform.Translate(0, Time.deltaTime * centerHorizontalSpeed, 0); // move forward
                center.transform.Rotate(0, Time.deltaTime * centerAngularSpeed, 0);
                Debug.Log(" GameState: PlayingFight", gameObject);
                break;
            case GameState.PlayingHyperSpace:

                break;
            case GameState.PlayingBonus:

                break;
            case GameState.PlayinPaused:

                break;
            case GameState.GameOver:

                player.chase = false;
                center.transform.Translate(0, 0, 0); //Durdur
                center.transform.Rotate(0, 0, 0);
                Debug.Log("Over", gameObject);

                break;
            default:
                break;
        }

    }

    public void quit()
    {
        Application.Quit();
    }
}
