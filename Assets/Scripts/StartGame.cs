﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void NewButton(){
				Time.timeScale = 1;
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");

    }
}
