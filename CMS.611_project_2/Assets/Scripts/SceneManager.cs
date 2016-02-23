using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public Level currentLevel;
	public GameObject mouseInterface;
	public Text posCount, negCount;
	public CreateChargeOnClick mouseScript;

	// Use this for initialization
	void Start () {
		currentLevel = Resources.Load<Level> ("DemoLevel");
		mouseInterface = Resources.Load<GameObject> ("MouseInterface");

		Level.Instantiate (currentLevel);
		GameObject.Instantiate (mouseInterface);
		mouseScript = mouseInterface.GetComponent<CreateChargeOnClick> ();

		posCount.text = currentLevel.getNumCharges (mouseScript.posCharge);
		negCount.text = currentLevel.getNumCharges (mouseScript.negCharge);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (currentLevel.consumeCharge (mouseScript.posCharge)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 position = new Vector3 (mousePosition [0], mousePosition [1], 0);
				GameObject newCharge = (GameObject) Instantiate (mouseScript.posCharge, position, Quaternion.identity);
				CircleCollider2D[] chargeColliders = newCharge.GetComponents<CircleCollider2D> ();
				CircleCollider2D innerCollider;
				if (chargeColliders [0].radius < chargeColliders [1].radius) {
					innerCollider = chargeColliders [0];
				} else {
					innerCollider = chargeColliders [1];
				}
				GameObject[] blockedRegions = GameObject.FindGameObjectsWithTag ("nope");
				foreach (GameObject box in blockedRegions)  {
					if (innerCollider.bounds.Intersects(box.GetComponent<BoxCollider2D>().bounds)) {
						Debug.Log ("hello?");
						GameObject.Destroy (newCharge);
						currentLevel.unconsumeCharge (mouseScript.posCharge);
						break;
					}
				}
				posCount.text = currentLevel.getNumCharges (mouseScript.posCharge);
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			if (currentLevel.consumeCharge (mouseScript.negCharge)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 position = new Vector3 (mousePosition [0], mousePosition [1], 0);
				GameObject newCharge = (GameObject) Instantiate (mouseScript.negCharge, position, Quaternion.identity);
				CircleCollider2D[] chargeColliders = newCharge.GetComponents<CircleCollider2D> ();
				CircleCollider2D innerCollider;
				if (chargeColliders [0].radius < chargeColliders [1].radius) {
					innerCollider = chargeColliders [0];
				} else {
					innerCollider = chargeColliders [1];
				}
				GameObject[] blockedRegions = GameObject.FindGameObjectsWithTag ("nope");
				foreach (GameObject box in blockedRegions)  {
					if (innerCollider.bounds.Intersects(box.GetComponent<BoxCollider2D>().bounds)) {
						GameObject.Destroy (newCharge);
						currentLevel.unconsumeCharge (mouseScript.negCharge);
						break;
					}
				}
				negCount.text = currentLevel.getNumCharges (mouseScript.negCharge);

			}
		}
	}
}
