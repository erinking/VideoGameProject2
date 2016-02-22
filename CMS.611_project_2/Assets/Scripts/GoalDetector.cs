using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour {

//	bool isComplete;

	void Start () {
//		isComplete = false;
	}

	void OnTriggerEnter2D(Collider2D other){
//		isComplete = true;
		Debug.Log ("Goal entered");
	}

}
