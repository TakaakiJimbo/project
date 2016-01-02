using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	GameObject startButton;
	GameObject howToPlayButton;
	GameObject intro;
	GameObject ranking;
	GameObject nowLoading;
	//GameObject rankingText;

	[SerializeField] private AudioClip sound;

	void Start() {
		startButton     = transform.FindChild ("START").gameObject;
		howToPlayButton = transform.FindChild ("HowToPlay").gameObject;
		intro           = transform.FindChild ("Intro").gameObject;
		ranking		    = transform.FindChild ("Rank").gameObject;
		nowLoading      = transform.FindChild ("NowLoading").gameObject;
		intro.SetActive (false);
		nowLoading.SetActive (false);
		ranking.SetActive (false);
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

	public void clickRankingButton () {
		GetComponent<AudioSource>().PlayOneShot(sound);
		ranking.SetActive (true);
	}
		
	public void clickIntro () {
		intro.SetActive (false);
	}

	public void clickRank () {
		ranking.SetActive (false);
	}

	private IEnumerator LoadScene(string scene) {
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevelAsync(scene);
	}
}
