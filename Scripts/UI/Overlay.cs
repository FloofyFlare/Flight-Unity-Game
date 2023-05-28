 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Overlay : MonoBehaviour {
    public GameObject pauseOverlay;
    public GameObject gameOverText;
    public GameObject playAgain;
    public GameObject MenuButton_W;
    public GameObject MenuButton_L;
    public GameObject winText;
    public bool pause = false;
    public Rigidbody2D rb2D;
    public int currentLevel;
    public UnityEvent MenuTransitionAd;
    public GameObject MenuPlayerController;
    public bool win = false;
    private bool adFailure = false;
// Use this for initialization
//resume and pause need to eventually be taken out
    public void Resume ()
    {
        pauseOverlay.SetActive(false);
        pause = false;
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
	public void Pause()
    {
        pause = true;
    }

    public void DeathOverlay()
    {
        if (win == false)
        {
            pauseOverlay.SetActive(true);
            gameOverText.SetActive(true);
            playAgain.SetActive(true);
            winText.SetActive(false);
            MenuButton_W.SetActive(false);
        }
    }
    public void WinOverlay()
    {
        pauseOverlay.SetActive(true);
        winText.SetActive(true);
        playAgain.SetActive(false);
        gameOverText.SetActive(false); 
        MenuButton_L.SetActive(false);
        
    }
    
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        currentLevel = 0;
        currentLevel = data.lvlprogress;
        Debug.Log("data.lvlprogress");
    }
    
    public void MenuTransition()
    {
        Player player = MenuPlayerController.GetComponent<Player>();
        if (win && adFailure == false)
        {
            MenuTransitionAd.Invoke();
            
        }
        else
        {

            
            player.LoadWeekSelection();
        }
        player.LoadWeekSelection();
    }
    public void AdFail()
    {
        adFailure = true;
    }
}
