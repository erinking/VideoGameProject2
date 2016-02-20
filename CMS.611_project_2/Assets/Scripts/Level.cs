using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Level : MonoBehaviour {

#region Fields
	private Dictionary<GameObject, int> chargeResources;
	private bool isComplete;
#endregion

#region Methods
	private abstract Dictionary<GameObject, int> getLevelChargeResources();

	public virtual bool levelCompleteCheck() {
		return isComplete;
	}
#endregion

#region Unity Callbacks
	virtual void Start () {
		chargeResources = new Dictionary<GameObject, int> ();
		isComplete = false;
	}
#endregion
}
