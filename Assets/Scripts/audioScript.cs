using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour {
    public AudioSource mainTheme;
    public AudioSource endMusic;
	// Use this for initialization
    void Awake()
    {
        StartGameMusic();
    }


	public void StartGameMusic () {
        //mainTheme = GetComponent<AudioSource>();
        mainTheme.Play();
	}

	public void GameOverMusic()
    {
        //endMusic = GetComponent<AudioSource>();
        mainTheme.Stop();
        endMusic.Play();
    }
}
