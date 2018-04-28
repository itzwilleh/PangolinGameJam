using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreDisplay;

	private int score = 0;
	private float multiplier = 1;
	
	private void Awake() {
		UpdateScore();
	}

	public void ResetScore() {
		score = 0;
		ResetMultiplier();
		UpdateScore();
	}

	public void ResetMultiplier() {
		multiplier = 1;
		UpdateScore();
	}

	public void AddScore(int toAdd) {
		score += (int)(toAdd * multiplier);
		UpdateScore();

		IncrementMultiplier();
	}

	public void IncrementMultiplier(float toAdd = 0.1f) {
		multiplier += toAdd;
		UpdateScore();
	}

	private void UpdateScore() {
		scoreDisplay.text = "SCORE: " + score + "\nx" + multiplier;
	}

}
