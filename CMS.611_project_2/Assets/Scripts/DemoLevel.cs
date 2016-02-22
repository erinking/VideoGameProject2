using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoLevel : Level {
	
	override public Dictionary<GameObject, int> getLevelChargeResources(){
		GameObject positiveCharge = Resources.Load<GameObject> ("PositiveCharge");
		GameObject negativeCharge = Resources.Load<GameObject> ("NegativeCharge");
		if (positiveCharge == null) {
			print ("thats no moon!");
		}
		Dictionary<GameObject, int> resources = new Dictionary<GameObject, int> ();
		resources.Add (positiveCharge, 3);
		resources.Add (negativeCharge, 3);

		print (resources.Keys.Count);
		if (resources == null) {
			print ("that kind of is a moon!");
		}

		return resources;

	}
}

