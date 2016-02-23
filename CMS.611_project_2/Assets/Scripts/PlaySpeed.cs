using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaySpeed : MonoBehaviour {
	public Button pauseButton;
	public Button playButton;
	public Button fastButton;

	// Use this for initialization
	void Start () {
		if (playButton == null)
			Time.timeScale = 2.0F; // start at normal speed.
		else {
			Time.timeScale = 0.0F; // start the game on pause.
			pauseButton.interactable = false;
			playButton.interactable = true;
			fastButton.interactable = true;
			pauseButton.onClick.AddListener (() => handleButton (pauseButton, playButton, fastButton, 0));
			playButton.onClick.AddListener (() => handleButton (pauseButton, playButton, fastButton, 1));
			fastButton.onClick.AddListener (() => handleButton (pauseButton, playButton, fastButton, 2));
		}
	}

	// newSpeed: 0 = pause, 1 = play, 2 = fast.
	void handleButton(Button pause, Button play, Button fast, int newSpeed) {
		switch (newSpeed) {
			case 0:
				Time.timeScale = 0.0F;
				pause.interactable = false;
				play.interactable = true;
				fast.interactable = true;
				break;
			case 1:
				Time.timeScale = 2.0F;
				pause.interactable = true;
				play.interactable = false;
				fast.interactable = true;
				break;
			case 2:
				Time.timeScale = 8.0F;
				pause.interactable = true;
				play.interactable = true;
				fast.interactable = false;
				break;
			default:
				Debug.Log ("why default?");
				Time.timeScale = 1.0F;
				pause.interactable = true;
				play.interactable = false;
				fast.interactable = true;
				break;
		}
	}

	// Update is called once per frame
	void Update() {
		
	}
}
