using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialLevel : Level {

	int tutorialStages = 0;
	bool tutStageComplete = false;
	GameObject positiveCharge;
	GameObject negativeCharge;
	
	override public Dictionary<GameObject, int> getLevelChargeResources(){
		positiveCharge = Resources.Load<GameObject> ("PositiveCharge");
		negativeCharge = Resources.Load<GameObject> ("NegativeCharge");
		Dictionary<GameObject, int> resources = new Dictionary<GameObject, int> ();
		resources.Add (positiveCharge, 5);
		resources.Add (negativeCharge, 5);
		return resources;
	}

	override public void makeWallsAndGoalAndQuaffle() {

	}

	public void Update() {
		if (!tutStageComplete) {
			switch (tutorialStages) {
			case 0: 
				if (GameObject.Find("PositiveCharge(Clone)") != null) {
					tutStageComplete = true;
					GameObject.Destroy (GameObject.Find ("AddPosChargeText"));
					GameObject text = Resources.Load<GameObject> ("AddPosChargeCompletedText");
					text = GameObject.Instantiate (text);
					text.transform.position = new Vector3 (10, -32, 0);
				}
				break;
			case 1:
				
				break;
			case 2:
				
				break;
			case 3:
				
				break;
			case 4:

				break;
			
			}

		}
	}
}
