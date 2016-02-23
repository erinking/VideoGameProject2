using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	// int level fron Build Settings
	public void LoadScene(int level) {
		Application.LoadLevel (level);
	}
}
