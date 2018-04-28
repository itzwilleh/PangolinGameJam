using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueBehaviour : MonoBehaviour {

	public ScoreManager _score;

	public GameObject originArea;
	public GameObject tonguePiece;
	//public BoxCollider2D coll;

	bool retracting = false;
	bool moving = false;

	public float moveSpeed = 0.02f;
	public float tonguePieceTimer = 0.5f;
	string moveDir = "Down";

	List<GameObject> tonguePieces = new List<GameObject>();

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Left")) {
			moveDir = "Left";
			Debug.Log("Left");
		} else if (Input.GetButtonDown("Right")) {
			moveDir = "Right";
			Debug.Log("Right");
		} else if (Input.GetButtonDown("Down")) {

			if (!moving && !retracting) {
				moving = true;
				InvokeRepeating("PlacePiece", tonguePieceTimer, tonguePieceTimer);
			}

			moveDir = "Down";
			Debug.Log("Down");
		}

		if (moving) {
			if (Input.GetButtonDown("Retract")) {
				moveDir = "Down";
				Retract();
			}
		}

	}


	void FixedUpdate() {
		if (moving && !retracting) {
			if (moveDir == "Left") {
				transform.position += new Vector3(-moveSpeed, 0, 0);
			} else if (moveDir == "Right") {
				transform.position += new Vector3(moveSpeed, 0, 0);
			} else {
				transform.position += new Vector3(0, -moveSpeed, 0);
			}
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log("Collided with: " + coll.transform.name);

		if (coll.GetComponent<EdibleBehaviour>() != null) {
			_score.AddScore(coll.GetComponent<EdibleBehaviour>().Eat());
		} else {
			Retract();
		}
	}


	private void Retract() {
		moving = false;
		CancelInvoke();
		transform.position = originArea.transform.position;

		for (int i = 0; i < tonguePieces.Count; i++) {
			Destroy(tonguePieces[i]);
		}

		tonguePieces = new List<GameObject>();

		_score.ResetMultiplier();
	}


	private void PlacePiece() {
		GameObject newPiece = Instantiate(tonguePiece, transform.position, Quaternion.identity);
		tonguePieces.Add(newPiece);
	}

}
