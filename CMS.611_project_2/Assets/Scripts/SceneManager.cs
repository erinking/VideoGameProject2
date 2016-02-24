using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public Level currentLevel;
	public GameObject mouseInterface;
	public Text posCount, negCount;
	public CreateChargeOnClick mouseScript;
	public Vector2 previousMousePosition;

	// Use this for initialization
	void Start () {
		mouseInterface = Resources.Load<GameObject> ("MouseInterface");

		Level.Instantiate (currentLevel);
		GameObject.Instantiate (mouseInterface);
		mouseScript = mouseInterface.GetComponent<CreateChargeOnClick> ();

		if (posCount != null)
			posCount.text = currentLevel.getNumCharges (mouseScript.posCharge);
		if (negCount != null)
			negCount.text = currentLevel.getNumCharges (mouseScript.negCharge);
		this.previousMousePosition = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mouseVelocity = (mousePosition - previousMousePosition) / Time.fixedDeltaTime;
		// Debug.Log (mousePosition.ToString() + ", " + previousMousePosition.ToString()  + ", " +  mouseVelocity.ToString() );
		//Debug.Log ("mouse velocity is" + mouseVelocity);

		if (Input.GetMouseButtonUp (0)) {
			createCharge (1, mousePosition, mouseVelocity);
		}
		if (Input.GetMouseButtonUp (1)) {
			createCharge (-1, mousePosition, mouseVelocity);
		}
		this.previousMousePosition = mousePosition;
	}

	private void createCharge(int chargeValue, Vector2 position, Vector2 velocity){
		/* Attempt to create a charge at the given position with the given velocity
		 * @param chargeValue: the type of charge to create. Equals -1 for negative charges or +1 for other charges.
		 * Does nothing if chargeValue is not -1 or +1.
		 * @param position: where to attempt to create the charge. If position is illegal (e.g, it is in a place where
		 * charges cannot go), this function will refuse to create it.
		 * @param velocity: the charge's initial velocity.
		 */

		// Forces applied to new particles from mouse movement are multiplied by this constant.
		float forceConstant = 0.6F;


		GameObject chargeToCreate = null;
		if (chargeValue == -1) {
			chargeToCreate = mouseScript.negCharge;
		} else if (chargeValue == 1) {
			chargeToCreate = mouseScript.posCharge;
		} else {
			Debug.LogError ("Tried to create a charge that was not positive or negative.");
			return;
		}
			
		if (currentLevel.consumeCharge (chargeToCreate)) {
//			Vector3 position3 = new Vector3 (position [0], position [1], 0);
			GameObject newCharge = (GameObject) Instantiate (chargeToCreate, position, Quaternion.identity);
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
					Debug.Log ("can't place a particle there!");
					GameObject.Destroy (newCharge);
					currentLevel.unconsumeCharge (chargeToCreate);
					break;
				}
			}

			// Check if it would hit anything a charge isn't allowed to go through.
			// This could happen if the user moved their mouse quicly enough.
//			RaycastHit2D whatItWillHit = Physics2D.Raycast (position, velocity.normalized, 
//				5 * Time.fixedDeltaTime * forceConstant * velocity.magnitude);
//			Debug.Log ("Casting ray whose distance is " + 5 * Time.fixedDeltaTime * forceConstant * velocity.magnitude);
//			if (whatItWillHit.collider != null && whatItWillHit.transform.tag == "nope") { // if it would hit something
//				Debug.Log ("would hit something at distance " + whatItWillHit.distance);
//				newCharge.GetComponent<Rigidbody2D> ().AddForce (whatItWillHit.distance * velocity.normalized, ForceMode2D.Impulse);
//			} else {
//				Debug.Log("wouldn't hit anything");
				newCharge.GetComponent<Rigidbody2D> ().AddForce (forceConstant * velocity, ForceMode2D.Impulse);
//			}
				
				


			if (chargeValue == 1 && posCount != null) {
				posCount.text = currentLevel.getNumCharges (mouseScript.posCharge);
			} else if (chargeValue == -1 && negCount != null) {
				negCount.text = currentLevel.getNumCharges (mouseScript.negCharge);
			}
				
		}



	}

}
