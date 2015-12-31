using UnityEngine;
using System.Collections;

public class MainButton : MonoBehaviour {

	GameObject startButton;
	GameObject howToPlayButton;
	GameObject intro;

	void Start() {
		startButton     = transform.FindChild ("START").gameObject;
		howToPlayButton = transform.FindChild ("HowToPlay").gameObject;
		intro           = transform.FindChild ("Intro").gameObject;
		intro.SetActive (false);
	}

	public void clickStartButton () {
		Application.LoadLevel("debug");
	}

	public void clickHowToPlayButton () {
		intro.SetActive (true);
	}

	public void clickIntro () {
		intro.SetActive (false);
	}
}
