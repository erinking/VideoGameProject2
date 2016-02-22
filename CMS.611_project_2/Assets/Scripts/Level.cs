using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Level : MonoBehaviour {

#region Fields
	public Dictionary<GameObject, int> chargeResources;
	public bool isComplete;
#endregion

#region Methods
	public abstract Dictionary<GameObject, int> getLevelChargeResources();


	public bool levelCompleteCheck() {
		return isComplete;
	}

	public bool tryConsumeCharge(GameObject prefab) {
		if (this.chargeResources.ContainsKey (prefab)) {
			if (this.chargeResources [prefab] > 0) {
				this.chargeResources[prefab] = this.chargeResources [prefab] - 1;
				return true;
			}
		}
		return false;
	}

	public bool consumeCharge(GameObject prefab) {
		if (this.chargeResources == null) {
			chargeResources = getLevelChargeResources ();
		}
		bool doesItWork = tryConsumeCharge (prefab);
		if (!doesItWork) {
			return false;
		}
		return true;
	}

	public void unconsumeCharge(GameObject prefab) {
		chargeResources [prefab] -= 1;
	}

	public abstract void makeWallsAndGoalAndQuaffle ();
#endregion

#region Unity Callbacks
	void Start () {
		isComplete = false;
	}
#endregion
}
