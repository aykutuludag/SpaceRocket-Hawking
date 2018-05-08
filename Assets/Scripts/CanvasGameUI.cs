using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameUI : MonoBehaviour
{

    public Canvas canvasGameUI, canvasPause, canvasGameOver;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText.text = "Score: " + ShipManager.Score;
    }
		
    public void updateScore()
    {
        if (!ShipManager.isGameOver && ShipManager.isGameStarted && !ShipManager.paused)
        {
            scoreText.text = "Score: " + ShipManager.Score;
        }
    }

    public void pauseGame()
    {
        ShipManager.paused = true;
        canvasPause.gameObject.SetActive(true);
    }
}
