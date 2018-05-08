using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMain : MonoBehaviour {

    public Canvas canvasInGame, canvasSettings, canvasStore;
	public GameManager gm;
    public void startTheGame()
    {
        transform.gameObject.SetActive(false);
        canvasInGame.gameObject.SetActive(true);
		gm.gamestate = GameManager.GameState.PlayingFight;
        Debug.Log("Oyun başlatılıyor");
    }

    public void showLeaderboard()
    {
        Debug.Log("Leaderboard tıklandı");
    }

    public void showAchievements()
    {
        Debug.Log("Başarımlar tıklandı");
    }

    public void showSettings()
    {
        Debug.Log("Ayarlar açıldı");
        canvasSettings.gameObject.SetActive(true);
    }

    public void openStore()
    {
        canvasStore.gameObject.SetActive(true);
    }
}
