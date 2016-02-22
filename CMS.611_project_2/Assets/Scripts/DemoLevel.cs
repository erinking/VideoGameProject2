using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoLevel : Level {
	
	override public Dictionary<GameObject, int> getLevelChargeResources(){
		GameObject positiveCharge = Resources.Load<GameObject> ("PositiveCharge");
		GameObject negativeCharge = Resources.Load<GameObject> ("NegativeCharge");
		Dictionary<GameObject, int> resources = new Dictionary<GameObject, int> ();
		resources.Add (positiveCharge, 15);
		resources.Add (negativeCharge, 15);
		return resources;

	}
}

