using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    public Canvas canvasMenu, canvasInGame, canvasPause, canvasGameOver, canvasSettings, canvasStore;

	// Use this for initialization
	void Start () {
        //Game opened
        canvasMenu.gameObject.SetActive(true);
        canvasInGame.gameObject.SetActive(false);
        canvasPause.gameObject.SetActive(false);
        canvasGameOver.gameObject.SetActive(false);
        canvasSettings.gameObject.SetActive(false);
        canvasStore.gameObject.SetActive(false);
    }
}
