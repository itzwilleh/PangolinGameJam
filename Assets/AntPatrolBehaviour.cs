using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPatrolBehaviour : MonoBehaviour {

	public float moveSpeed = 0.35f;
	public int facingDirection = 1; //Positive is forward, negative is backwards

	int layerMask = 512;

	void Awake() {
		//Debug.Log(LayerMask.GetMask("World"));
	}

	void FixedUpdate () {
		Debug.DrawRay(transform.position, new Vector2(facingDirection, 0), Color.white);

		if(Physics2D.Raycast(transform.position,
												 new Vector2(facingDirection, 0),
												 1, layerMask)) {
				Debug.Log("Collide");

				facingDirection = facingDirection * -1;
		}


		transform.position += new Vector3(facingDirection * moveSpeed, 0, 0);

	}

	


}
