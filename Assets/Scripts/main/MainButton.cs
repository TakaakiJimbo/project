using UnityEngine;
using System.Collections;

public class MainButton : MonoBehaviour {

	GameObject startButton;
	GameObject howToPlayButton;
	GameObject intro;
	GameObject nowLoading;

	void Start() {
		startButton     = transform.FindChild ("START").gameObject;
		howToPlayButton = transform.FindChild ("HowToPlay").gameObject;
		intro           = transform.FindChild ("Intro").gameObject;
		nowLoading      = transform.FindChild ("NowLoading").gameObject;
		intro.SetActive (false);
		nowLoading.SetActive (false);
	}

	public void clickStartButton () {
		startButton.SetActive (false);
		howToPlayButton.SetActive (false);
		nowLoading.SetActive (true);
		Application.LoadLevelAsync("debug");
	}

	public void clickHowToPlayButton () {
		intro.SetActive (true);
	}

	public void clickIntro () {
		intro.SetActive (false);
	}
}
