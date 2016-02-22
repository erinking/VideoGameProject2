using UnityEngine;
using System.Collections;

public class CreateChargeOnClick : MonoBehaviour {


	public GameObject posCharge;
	public GameObject negCharge;

	// Use this for initialization
	void Start () {
		posCharge = Resources.Load<GameObject> ("PositiveCharge");
		negCharge = Resources.Load<GameObject> ("NegativeCharge");
	}
}
