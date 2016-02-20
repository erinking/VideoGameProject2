using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public Object currentLevel;
	public Object mouseInterface;

	// Use this for initialization
	void Start () {
		currentLevel = Resources.Load ("DemoLevel");
		mouseInterface = Resources.Load ("MouseInterface");
		GameObject.Instantiate (currentLevel);
		GameObject.Instantiate (mouseInterface);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
