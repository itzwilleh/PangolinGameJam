
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public Text timeText;
    int tickClock = 120;
    // Use this for initialization
    void Start() {        
        InvokeRepeating("pangolinClock", 0.0f, 1.0f);        
    }

    // Update is called once per frame
    void pangolinClock() {        
        --tickClock;
        timeText.text = "Timer: " + tickClock;
    }

    

    



}
