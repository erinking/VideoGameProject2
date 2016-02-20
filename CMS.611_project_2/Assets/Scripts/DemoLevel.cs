using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoLevel : Level {

	public override Dictionary<GameObject, int> getLevelChargeResources(){
		GameObject positiveCharge = GameObject.Find("PositiveCharge");
		GameObject negativeCharge = GameObject.Find ("NegativeCharge");
		Dictionary<GameObject, int> resources = new Dictionary<GameObject, int> ();
		resources.Add(positiveCharge, 3);
		resources.Add (negativeCharge, 3);
		return resources;
	}
}
