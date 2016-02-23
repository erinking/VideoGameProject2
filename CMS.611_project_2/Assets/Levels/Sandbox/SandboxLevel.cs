using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SandboxLevel : Level {

	override public Dictionary<GameObject, int> getLevelChargeResources(){
		GameObject positiveCharge = Resources.Load<GameObject> ("PositiveCharge");
		GameObject negativeCharge = Resources.Load<GameObject> ("NegativeCharge");
		Dictionary<GameObject, int> resources = new Dictionary<GameObject, int> ();
		resources.Add (positiveCharge, 100);
		resources.Add (negativeCharge, 100);
		return resources;
	}

	override public void makeWallsAndGoalAndQuaffle() {

	}
}
