using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleBehaviour : MonoBehaviour {


	public int pointValue;

	public void Eat() {
		Debug.Log("You ate: " + name + ", worth " + pointValue + " points");
		Destroy(this.gameObject);
	}

}
