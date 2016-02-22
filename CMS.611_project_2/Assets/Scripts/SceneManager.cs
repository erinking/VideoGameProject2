using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public Level currentLevel;
	public GameObject mouseInterface;
	public CreateChargeOnClick mouseScript;

	// Use this for initialization
	void Start () {
		currentLevel = Resources.Load<Level> ("DemoLevel");
		mouseInterface = Resources.Load<GameObject> ("MouseInterface");
		Level.Instantiate (currentLevel);
		GameObject.Instantiate (mouseInterface);
		mouseScript = mouseInterface.GetComponent<CreateChargeOnClick> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (currentLevel.consumeCharge (mouseScript.posCharge)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 position = new Vector3 (mousePosition [0], mousePosition [1], 0);
				Instantiate (mouseScript.posCharge, position, Quaternion.identity);
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			if (currentLevel.consumeCharge (mouseScript.negCharge)) {
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 position = new Vector3 (mousePosition [0], mousePosition [1], 0);
				Instantiate (mouseInterface.GetComponent<CreateChargeOnClick> ().negCharge, position, Quaternion.identity);
			}
		}
	}
}
