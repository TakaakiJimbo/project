using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	[SerializeField] private AudioClip sound;
	MyCarLifePoint carLife;

	void Start() {
		gameObject.transform.FindChild("Retry").gameObject.SetActive(false);
		gameObject.transform.FindChild("Title").gameObject.SetActive(false);
		gameObject.transform.FindChild("Stop").gameObject.SetActive(false);
		carLife = GameObject.Find("Car0").GetComponent<MyCarLifePoint>();
	}

	public void Retry() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		Time.timeScale = 1f;
		StartCoroutine("LoadScene", "noukin");
	}

	public void BackTitle() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		Time.timeScale = 1f;
		StartCoroutine("LoadScene", "main");
	}

	private IEnumerator LoadScene(string scene) {
		yield return new WaitForSeconds(0.5f);
		Application.LoadLevelAsync(scene);
	}

	public void StopGame() {
		GetComponent<AudioSource>().PlayOneShot(sound);
		StartCoroutine("ResultGame");
	}

	private IEnumerator ResultGame() {
		gameObject.transform.FindChild("Stop").gameObject.SetActive(false);
		yield return new WaitForSeconds(2.0f);
		Time.timeScale = 0f;
		carLife.checkScore();
		gameObject.transform.FindChild("Retry").gameObject.SetActive(true);
		gameObject.transform.FindChild("Title").gameObject.SetActive(true);
	}
}