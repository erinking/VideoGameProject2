using UnityEngine;
using System.Collections;

public class CreateChargeOnClick : MonoBehaviour {


	public Object posCharge;
	public Object negCharge;

	// Use this for initialization
	void Start () {
		posCharge = Resources.Load ("PositiveCharge");
		negCharge = Resources.Load ("NegativeCharge");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 position = new Vector3 (mousePosition [0], mousePosition [1], 0);
			Instantiate (posCharge, position, Quaternion.identity);
		}
		if (Input.GetMouseButtonDown (1)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector3 position = new Vector3 (mousePosition [0], mousePosition [1], 0);
			Instantiate (negCharge, position, Quaternion.identity);
		}
	}
}
