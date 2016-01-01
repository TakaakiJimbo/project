using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	GameObject startButton;
	GameObject howToPlayButton;
	GameObject intro;
	GameObject nowLoading;

	[SerializeField] private AudioClip sound;

	void Start() {
		startButton     = transform.FindChild ("START").gameObject;
		howToPlayButton = transform.FindChild ("HowToPlay").gameObject;
		intro           = transform.FindChild ("Intro").gameObject;
		nowLoading      = transform.FindChild ("NowLoading").gameObject;
		intro.SetActive (false);
		nowLoading.SetActive (false);
	}

	public void clickStartButton () {
		GetComponent<AudioSource>().PlayOneShot(sound);
		startButton.SetActive (false);
		howToPlayButton.SetActive (false);
		nowLoading.SetActive (true);
		StartCoroutine ("LoadScene", "debug");
	}

	public void clickHowToPlayButton () {
		GetComponent<AudioSource>().PlayOneShot(sound);
		intro.SetActive (true);
	}

	public void clickIntro () {
		intro.SetActive (false);
	}

	private IEnumerator LoadScene(string scene) {
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevelAsync(scene);
	}
}
