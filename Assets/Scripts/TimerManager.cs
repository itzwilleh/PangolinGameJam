
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public Text timeText, gameOverText;

    public audioScript _as;

    int TickClock = 100;
    // Use this for initialization
    void Start() {
        InvokeRepeating("pangolinClock", 0.0f, 1.0f);
    }

    public void SetTimer(int time) {
      TickClock = time;
    }

    void pangolinClock() {

        if (TickClock == 0)
        {
            GameOver();
        }else if (TickClock > 0)
        {
            --TickClock;
            timeText.text = "Timer: " + TickClock;
        }
    }

    public void GameOver(){
        gameOverText.text = "Game Over!";
        //change to private later on.
        Time.timeScale = 0;
        _as.GameOverMusic();
    }


    public void GameWon() {
      gameOverText.text = "WINNER WINNER\nPANGOLIN DINNER";
      Time.timeScale = 0;
      _as.GameOverMusic();
    }






}
