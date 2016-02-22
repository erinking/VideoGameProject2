using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour {

	bool isComplete;

	void Start () {
		this.isComplete = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Goal was hit");
	}

}
