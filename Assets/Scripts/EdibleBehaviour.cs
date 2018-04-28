using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBehaviour : MonoBehaviour {

	public int pointValue;

	public int Eat() {
		Debug.Log("You ate: " + name + ", worth " + pointValue + " points");
		Destroy(this.gameObject);

		return pointValue;
	}

}
