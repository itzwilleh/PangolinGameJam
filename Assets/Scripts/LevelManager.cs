using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public static LevelManager lvlMg;

	public int currentLevel = 0;

	public TimerManager _timer;
	public ScoreManager _score;
	public SpriteRenderer _cameraTint;

	public Level currentLevelData;
	public GameObject antBasin;
	public GameObject antPrefab;

	private Level[] levels;
	public GameObject[] levelObjects;

	private bool[] levelsDone;
	private int maxLevel; //Equal to number of levels

	public int antsLeft;

	List<GameObject> activeAnts = new List<GameObject>();

	public void Awake() {

		lvlMg = this;

		Debug.Log(levelObjects.Length);

		maxLevel = levelObjects.Length;
		levelsDone = new bool[levelObjects.Length];

		if (antBasin == null) {
			antBasin = GameObject.FindGameObjectWithTag("Ant Basin");
		}

		for (int i = 0; i < levelsDone.Length; i++) {
			Debug.Log(levelsDone[i]);
		}

		levels = new Level[10] {
			new Level(4, 1, 60, new Color(0.05f, 0.05f, 0.08f, 0.4f)),
			new Level(5, 1.05f, 60, new Color(0.05f, 0.05f, 0.08f, 0.3f)),
			new Level(6, 1.1f, 60, new Color(0.05f, 0.05f, 0.08f, 0.2f)),
			new Level(10, 1.20f, 70, Color.white),
			new Level(11, 1.30f, 70, Color.white),
			new Level(12, 1.40f, 70, new Color(0.05f, 0.05f, 0.08f, 0.2f)),
			new Level(13, 1.50f, 68, new Color(0.05f, 0.05f, 0.08f, 0.3f)),
			new Level(11, 1.30f, 70, Color.white),
			new Level(14, 1.75f, 66, new Color(0.05f, 0.05f, 0.08f, 0.4f)),
			new Level(15, 2f, 64, new Color(0.05f, 0.05f, 0.08f, 0.44f)),
		};

		LoadLevel();

	}

	public void LoadLevel() {

		currentLevelData = levels[currentLevel];
		levelObjects[currentLevel].SetActive(true);

		for (int i = 0; i < currentLevelData.GetQuantity(); i++) {
			activeAnts.Add(NewAnt(currentLevelData.GetSpeed()));
		}

		antsLeft = AntPatrolBehaviour.antCounter;

		_timer.SetTimer(currentLevelData.GetTime());

		_cameraTint.color = currentLevelData.GetTint();

	}

	public static void AntKilled() {
		lvlMg.antsLeft--;

		if (lvlMg.antsLeft <= 0) {
			Debug.Log("NO ANTS LEFT");
			lvlMg.LevelDone();
		}
	}

	public void LevelDone() {

		levelObjects[currentLevel].SetActive(false);

		currentLevel++;

		if (currentLevel >= maxLevel) {
			_timer.GameWon();
		}

		LoadLevel();

	}


	private GameObject NewAnt(float speed = 1) {

		float basinWidth = antBasin.transform.localScale.x;

		Vector3 antPos = new Vector3(Random.Range(-basinWidth, basinWidth), antBasin.transform.position.y);
		GameObject newAnt = Instantiate(antPrefab, antPos, Quaternion.identity);

		newAnt.GetComponent<AntPatrolBehaviour>().ModifySpeed(speed);

		return newAnt;
	}

	public void Update () {
		if (Input.GetKeyDown("l")) {
			LevelDone();
		}
	}

}

public struct Level {

	public Level(int q, float s, int t, Color ti) {
		this.quantity = q;
		this.speed = s;
		this.time = t;
		this.tint = ti;
	}

	int quantity;
	float speed;
	int time;
	Color tint;

	public int GetQuantity() {
		return quantity;
	}

	public float GetSpeed() {
		return speed;
	}

	public int GetTime() {
		return time;
	}

	public Color GetTint() {
		return tint;
	}


}
