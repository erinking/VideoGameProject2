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

	public virtual bool levelCompleteCheck() {
		return isComplete;
	}
#endregion

#region Unity Callbacks
	void Start () {
		chargeResources = new Dictionary<GameObject, int> ();
		isComplete = false;
	}
#endregion
}
