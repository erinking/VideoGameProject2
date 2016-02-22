using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour {

//	bool isComplete;

	void Start () {
//		isComplete = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
	//		isComplete = true;
		Debug.Log ("Goal entered");
		this.gameObject.GetComponentInParent<SpriteRenderer> ().color = UnityEngine.Color.green;
	}

}
