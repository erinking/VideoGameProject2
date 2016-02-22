using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour {

//	bool isComplete;

	void Start () {
//		isComplete = false;
	}

	void OnTriggerEnter2D(Collider2D coll){
	//		isComplete = true;
		Color goalReachedColor = new Color ();
		ColorUtility.TryParseHtmlString ("#619F27C7", out goalReachedColor);
		this.gameObject.GetComponentInParent<SpriteRenderer> ().color = goalReachedColor;
	}

}
