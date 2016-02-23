using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Puzzle1Level : Level {
	
	override public Dictionary<GameObject, int> getLevelChargeResources(){
		GameObject positiveCharge = Resources.Load<GameObject> ("PositiveCharge");
		GameObject negativeCharge = Resources.Load<GameObject> ("NegativeCharge");
		Dictionary<GameObject, int> resources = new Dictionary<GameObject, int> ();
		resources.Add (positiveCharge, 20);
		resources.Add (negativeCharge, 30);
		return resources;
	}

	override public void makeWallsAndGoalAndQuaffle() {

	}
}
